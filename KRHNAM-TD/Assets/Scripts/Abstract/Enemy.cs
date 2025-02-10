
using UnityEngine;

public abstract class Enemy : Entity
{

    public EnemyData enemyData;

    public Element element;
    private HealthBar healthBar;
    public float Hp { get; set; }

    public void Start()
    {
        healthBar = transform.Find("HealthbarCanva").Find("Healthbar").GetComponent<HealthBar>();
        healthBar.SetMaxHealth(enemyData.MaxHp);
        Hp = enemyData.MaxHp;
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
}
