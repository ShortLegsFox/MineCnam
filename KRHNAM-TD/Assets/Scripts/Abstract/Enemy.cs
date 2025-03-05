using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public abstract class Enemy : Entity
{

    [SerializeField] public EnemyData enemyData;
    [SerializeField] public Element element;
    public Image debuffIcon;
    private HealthBar healthBar;
    
    public float hp;
    public int armor;
    public bool isParasitized;
    public GameObject target;

    private bool _canAttack = true;
    private Animator _animator;
    private List<Effect> _activeEffects = new List<Effect>();
    

    public void Start()
    {
        healthBar = transform.Find("HealthbarCanva").Find("Healthbar").GetComponent<HealthBar>();
        debuffIcon = transform.Find("DebuffCanva").Find("DebuffIcon").GetComponent<Image>();
        InitializeStats();
        InitializeReference();
    }

    public void Update()
    {
        IsTheTargetInRange();
        ApplyEffects();
    }

    private void InitializeStats()
    {
        hp = enemyData.MaxHp;
        armor = enemyData.Armor;
        isParasitized = false;

        if (healthBar != null)
        {
            healthBar.SetMaxHealth(enemyData.MaxHp);
        }

        if (debuffIcon != null)
        {
            debuffIcon.enabled = false;
        }
    }

    private void InitializeReference()
    {
        _animator = GetComponent<Animator>();
        target = GameManager.Instance.Castle;
    }

    public bool TakeDamage(Element attackElement, float attackDamage, EffectData effectData = null)
    {
        float finalDamage = CalculateElementalDamage(attackElement, attackDamage);
        
        if (effectData)
        {
            ApplyStatusEffect(attackElement, effectData);
        }

        ApplyDamageOnHP(ReduceDamageWithArmor(finalDamage));

        return CheckDeath();
    }

    private float CalculateElementalDamage(Element attackElement, float attackDamage)
    {
        if (attackElement == GetElementInfos.GetWeakness(element))
        {
            attackDamage = GetElementInfos.AddStrongDamage(attackDamage);
        }

        if (attackElement == GetElementInfos.GetStrength(element))
        {
            attackDamage = GetElementInfos.RemoveWeakDamage(attackDamage);
        }

        return attackDamage;
    }

    private void ApplyStatusEffect(Element attackElement, EffectData effectData)
    {
        Effect effect = GetElementInfos.GetEffect(attackElement, effectData);
        if (effect != null)
        {
            AddEffect(effect);
        }
    }

    private float ReduceDamageWithArmor(float AttackDamage)
    {
        float damageReducer = 1 - (armor / 200f);
        return damageReducer * AttackDamage;
    }

    private void ApplyDamageOnHP(float AttackDamage)
    {
        this.hp -= AttackDamage;
        healthBar.TakeDamage(AttackDamage);
    }
    
    private void AddEffect(Effect newEffect)
    {
        foreach (Effect effect in _activeEffects)
        {
            if (effect.GetElement() == newEffect.GetElement())
            {
                effect.Refresh();
                return;
            }
        }
        _activeEffects.Add(newEffect);
    }

    private void ApplyEffects()
    {
        if (hp >= 0)
        {
            for (int i = _activeEffects.Count - 1; i >= 0; i--)
            {
                if (_activeEffects[i].Apply(this) == false)
                {
                    _activeEffects.RemoveAt(i);   
                }
            }
        }
    }
    
    private float GetDistanceFromTarget()
    {
        if (target != null)
        {
            float distance = Vector3.Distance(target.transform.position, transform.position);
            return distance;
        }
        return 1000;
    }

    private void IsTheTargetInRange()
    {
        if (_canAttack && GetDistanceFromTarget() < enemyData.Range)
        {
            _canAttack = false;
            _animator.SetTrigger("Attack");
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

            Enemy enemy = target.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(element, enemyData.Damage);
                StartCoroutine(AttackCooldown());
            }
        }
    }

    private IEnumerator AttackCooldown()
    {
        _canAttack = false;
        yield return new WaitForSeconds(enemyData.TimeBetweenAttacks);
        _canAttack = true;
    }
    
    public Enemy FindNearestEnemy()
    {
        Enemy[] allEnemies = FindObjectsByType<Enemy>(FindObjectsSortMode.None);
        Enemy nearestEnemy = null;
        float minDistance = Mathf.Infinity;

        foreach (Enemy e in allEnemies)
        {
            if (e == this) continue;

            float distance = Vector3.Distance(transform.position, e.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                nearestEnemy = e;
            }
        }
        
        return nearestEnemy;
    }

    private bool CheckDeath()
    {
        if (hp <= 0)
        {
            OnDeath();
            return true;
        }
        return false;
    }

    private void OnDeath()
    {
        Destroy(this.gameObject);
        StoreManager.Instance.AddGold(enemyData.GoldWon);
    }
}
