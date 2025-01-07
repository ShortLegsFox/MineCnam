namespace Abstract
{
    public abstract class Tower : Entity
    {
        public TowerData towerData;

        public int Hp { get; set; }

        public abstract void Attack();

    }
}
