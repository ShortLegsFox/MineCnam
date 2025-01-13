public abstract class Enemy : Entity
{
    public GetElementInfos ElementInfos;
    public EnemyData enemyData;

    public float Hp { get; set; }

    public void TakeDamage(Element AttackElement, float AttackDamage)
    {
        // If tower is strong VS enemy
        if (AttackElement == ElementInfos.GetWeakness(enemyData.Element))
        {
            AttackDamage = ElementInfos.AddStrongDamage(AttackDamage);
        }

        // If tower is weak vs enemy
        if (AttackElement == ElementInfos.GetStrength(enemyData.Element))
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
