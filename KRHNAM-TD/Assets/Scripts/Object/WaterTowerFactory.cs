using Interface;
using UnityEngine;

namespace TDObject
{
    public class WaterTowerFactory : I_TowerFactory
    {
        private WaterTower _waterTowerPrefab;

        public override I_Tower CreateTower()
        {
            return _waterTowerPrefab;
        }
    }
}