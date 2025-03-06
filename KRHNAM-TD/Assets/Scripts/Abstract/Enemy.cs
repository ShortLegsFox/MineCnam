using Abstract;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : Entity
{

    public EnemyData enemyData;
    public float Hp { get; set; }
    public int Armor { get; set; }
    public int currentSpeed { get; set; }
    public GameObject Target { get; set; }
    public bool isParasitized = false;
    public Image debuffIcon;

    private HealthBar healthBar;
    private bool canAttack = true;
    private Animator animator;
    private List<Effect> activeEffects = new List<Effect>();
    private MovementStrategy movementStrategy;



    public void Start()
    {
        healthBar = transform.Find("HealthbarCanva").Find("Healthbar").GetComponent<HealthBar>();
        healthBar.SetMaxHealth(enemyData.MaxHp);
        Hp = enemyData.MaxHp;
        Armor = enemyData.Armor;
        currentSpeed = enemyData.MoveSpeed;
        animator = GetComponent<Animator>();
        debuffIcon = transform.Find("DebuffCanva").Find("DebuffIcon").GetComponent<Image>();
        debuffIcon.enabled = false;
        Target = GameManager.Instance.Castle;
        movementStrategy = Instantiate(enemyData.movementStrategy);
        movementStrategy.Initialize(this);
    }

    public void Update()
    {
        IsTheTargetInRange();
        ApplyEffects();
        Move();
    }

    private void Move()
    {
        if (movementStrategy != null)
        {
            movementStrategy.Move();
        }
    }

    public bool TakeDamage(Element AttackElement, float AttackDamage, bool fromEffect = false, EffectData effectData = null)
    {
        // If tower is strong VS enemy
        if (AttackElement == GetElementInfos.GetWeakness(enemyData.element))
        {
            AttackDamage = GetElementInfos.AddStrongDamage(AttackDamage);
        }

        // If tower is weak vs enemy
        if (AttackElement == GetElementInfos.GetStrength(enemyData.element))
        {
            AttackDamage = GetElementInfos.RemoveWeakDamage(AttackDamage);
        }

        Effect effect = GetElementInfos.GetEffect(AttackElement, effectData);

        if (effect != null && fromEffect == false)
        {
            AddEffect(effect);
        }

        ApplyDamageOnHP(ReduceDamageWithArmor(AttackDamage));

        return OnDeath();
    }

    private float ReduceDamageWithArmor(float AttackDamage)
    {
        float damageReducer = 1 - (Armor / 200f);
        return damageReducer * AttackDamage;
    }

    private void ApplyDamageOnHP(float AttackDamage)
    {
        this.Hp -= AttackDamage;
        healthBar.TakeDamage(AttackDamage);
    }

    private void AddEffect(Effect newEffect)
    {
        foreach (Effect effect in activeEffects)
        {
            if (effect.GetElement() == newEffect.GetElement())
            {
                effect.Refresh();
                return;
            }
        }
        activeEffects.Add(newEffect);
    }

    private void ApplyEffects()
    {
        if (Hp >= 0)
        {
            for (int i = activeEffects.Count - 1; i >= 0; i--)
            {
                if (activeEffects[i].Apply(this) == false)
                {
                    activeEffects.RemoveAt(i);
                }
            }
        }
    }

    private float GetDistanceFromTarget()
    {
        // Get distance from target
        if (Target != null)
        {
            float distance = Vector3.Distance(Target.transform.position, transform.position);
            return distance;
        }
        return 1000;
    }

    //Methode pour verifier si l'ennemi est a port�e d'attaque
    private void IsTheTargetInRange()
    {
        if (canAttack && GetDistanceFromTarget() < enemyData.Range)
        {
            canAttack = false;
            animator.SetTrigger("Attack");
        }
    }

    public void Attack()
    {
        if (Target != null)
        {
            Castle castle = Target.GetComponent<Castle>();
            if (castle != null)
            {
                castle.TakeDamage(enemyData.Damage);
                StartCoroutine(AttackCooldown());
            }

            Enemy enemy = Target.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(enemyData.element, enemyData.Damage, true);
                StartCoroutine(AttackCooldown());
            }
        }
    }

    private IEnumerator AttackCooldown()
    {
        canAttack = false;
        yield return new WaitForSeconds(enemyData.TimeBetweenAttacks);
        canAttack = true;
    }

    public Enemy FindClosestEnemy()
    {
        Enemy[] allEnemies = FindObjectsByType<Enemy>(FindObjectsSortMode.None);
        Enemy closestEnemy = null;
        float minDistance = Mathf.Infinity;

        foreach (Enemy e in allEnemies)
        {
            if (e == this) continue;

            float distance = Vector3.Distance(transform.position, e.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                closestEnemy = e;
            }
        }

        return closestEnemy;
    }

    private bool OnDeath()
    {
        if (Hp <= 0)
        {
            Destroy(this.gameObject);
            StoreManager.Instance.AddGold(enemyData.GoldWon);
            return true;
        }
        return false;
    }
}
