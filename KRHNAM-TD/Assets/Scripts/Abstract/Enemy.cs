using System;
using UnityEngine;

public abstract class Enemy : Entity
{
    public GetElementInfos ElementInfos;
    public EnemyData enemyData;
    
    public Element element;
    public float Hp { get; set; }

    public void TakeDamage(Element AttackElement, float AttackDamage)
    {
        // If tower is strong VS enemy
        if (AttackElement == ElementInfos.GetWeakness(element))
        {
            AttackDamage = ElementInfos.AddStrongDamage(AttackDamage);
        }

        // If tower is weak vs enemy
        if (AttackElement == ElementInfos.GetStrength(element))
        {
            AttackDamage = ElementInfos.RemoveWeakDamage(AttackDamage);
        }

        this.Hp -= AttackDamage;

        if(Hp <= 0) 
        {
            Destroy(this);
        }
    }
}
