using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Entity
{

    public EnemyData enemyData;

    public Element element;
    private HealthBar healthBar;
    public float Hp { get; set; }
    public int currentSpeed { get; set; }

    private GameObject target;
    private bool canAttack = true;
    private Animator animator;
    
    private List<Effect> activeEffects = new List<Effect>();

    public void Start()
    {
        healthBar = transform.Find("HealthbarCanva").Find("Healthbar").GetComponent<HealthBar>();
        healthBar.SetMaxHealth(enemyData.MaxHp);
        Hp = enemyData.MaxHp;
        currentSpeed = enemyData.MoveSpeed;
        target = GameManager.Instance.Castle;
        animator = GetComponent<Animator>();
    }

    public void Update()
    {
        IsTheTargetInRange();
        
        ApplyEffects();

    }

    public bool TakeDamage(Element AttackElement, float AttackDamage)
    {
        // If tower is strong VS enemy
        if (AttackElement == GetElementInfos.GetWeakness(element))
        {
            AttackDamage = GetElementInfos.AddStrongDamage(AttackDamage);
        }

        // If tower is weak vs enemy
        if (AttackElement == GetElementInfos.GetStrength(element))
        {
            AttackDamage = GetElementInfos.RemoveWeakDamage(AttackDamage);
        }

        Effect effect = GetElementInfos.GetEffect(AttackElement);
        
        if (effect != null)
        {
            AddEffect(effect);
        }

        this.Hp -= AttackDamage;
        healthBar.TakeDamage(AttackDamage);


        return OnDeath();
    }
    
    private void AddEffect(Effect newEffect)
    {
        foreach (Effect effect in activeEffects)
        {
            if (effect.GetType() == newEffect.GetType())
            {
                return;
            }
        }
        activeEffects.Add(newEffect);
    }

    private void ApplyEffects()
    {
        if (Hp >= 0)
        {
            for (int i = 0; i < activeEffects.Count; i++)
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
        if (target != null)
        {
            float distance = Vector3.Distance(target.transform.position, transform.position);
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
        if (target != null)
        {
            Castle castle = target.GetComponent<Castle>();
            if (castle != null)
            {
                castle.TakeDamage(enemyData.Damage);
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
