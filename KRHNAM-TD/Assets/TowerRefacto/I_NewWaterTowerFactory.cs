using Abstract;

namespace Interface
{
    public interface I_NewWaterTowerFactory
    {
        public Tower CreateBasicTower();
        public Tower CreateAdvancedTower();
        public Tower CreateUltimateTower();
    }
}
