using Abstract;
using UnityEngine;

namespace Interface
{
    public interface I_TowerFactory
    {
        public Tower CreateBasicTower(Vector3? position = null);
        public Tower CreateAdvancedTower(Vector3? position = null);
        public Tower CreateUltimateTower(Vector3? position = null);
    }
}
