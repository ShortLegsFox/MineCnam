using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public abstract class Enemy : Entity
{

    public EnemyData enemyData;
    public Element element;
    public float hp;
    public int armor;
    public GameObject target;
    public bool isParasitized;
    public Image debuffIcon;

    private HealthBar _healthBar;
    private bool _canAttack = true;
    private Animator _animator;
    private List<Effect> _activeEffects = new List<Effect>();


    public void Start()
    {
        _healthBar = transform.Find("HealthbarCanva").Find("Healthbar").GetComponent<HealthBar>();
        _healthBar.SetMaxHealth(enemyData.MaxHp);
        hp = enemyData.MaxHp;
        armor = enemyData.Armor;
        target = GameManager.Instance.Castle;
        _animator = GetComponent<Animator>();
        debuffIcon = transform.Find("DebuffCanva").Find("DebuffIcon").GetComponent<Image>();
        debuffIcon.enabled = false;
        isParasitized = false;
    }

    public void Update()
    {
        IsTheTargetInRange();
        ApplyEffects();
    }

    public bool TakeDamage(Element AttackElement, float AttackDamage, bool fromEffect = false, EffectData effectData = null)
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
        float damageReducer = 1 - (armor / 200f);
        return damageReducer * AttackDamage;
    }

    private void ApplyDamageOnHP(float AttackDamage)
    {
        this.hp -= AttackDamage;
        _healthBar.TakeDamage(AttackDamage);
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
                enemy.TakeDamage(element, enemyData.Damage, true);
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
        if (hp <= 0)
        {
            Destroy(this.gameObject);
            StoreManager.Instance.AddGold(enemyData.GoldWon);
            return true;
        }
        return false;
    }
}
