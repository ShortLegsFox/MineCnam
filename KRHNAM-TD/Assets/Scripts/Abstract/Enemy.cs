using System.Collections;
using UnityEngine;

public abstract class Enemy : Entity
{

    public EnemyData enemyData;

    public Element element;
    private HealthBar healthBar;
    public float Hp { get; set; }

    private GameObject target;
    private bool canAttack = true;
    private Animator animator;

    public void Start()
    {
        healthBar = transform.Find("HealthbarCanva").Find("Healthbar").GetComponent<HealthBar>();
        healthBar.SetMaxHealth(enemyData.MaxHp);
        Hp = enemyData.MaxHp;
        target = GameManager.Instance.Castle;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        IsTheTargetInRange();
    }

    public bool TakeDamage(Element AttackElement, float AttackDamage)
    {
        Debug.Log("TakeDamage");
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

        this.Hp -= AttackDamage;
        healthBar.TakeDamage(AttackDamage);

        if (Hp <= 0)
        {
            Destroy(this.gameObject);
            return true;
        }
        return false;
    }


    private float GetDistanceFromTarget()
    {
        // Get distance from target
        if (target != null)
        {
            float distance = Vector3.Distance(target.transform.position, transform.position);
            Debug.Log(distance);
            return distance;
        }
        return 1000;
    }

    //Methode pour verifier si l'ennemi est a portée d'attaque
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
}
