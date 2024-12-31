using System;
using Interface;
using UnityEngine;

namespace TDObject
{
    public class FireTowerFactory : I_TowerFactory
    {
        public FireTower _fireTowerPrefab;

        public override I_Tower CreateTower()
        {
            return _fireTowerPrefab;
        }
    }
}