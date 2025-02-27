using Abstract;

namespace Interface
{
    public interface I_TowerFactory
    {
        public Tower CreateBasicTower();
        public Tower CreateAdvancedTower();
        public Tower CreateUltimateTower();
    }
}
