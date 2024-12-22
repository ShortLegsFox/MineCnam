using Interface;
using UnityEngine;

namespace TDObject
{
    public class WaterTowerFactory : MonoBehaviour, I_TowerFactory
    {
        private WaterTower waterTowerPrefab;

        public GameObject CreateTower(Vector3 position)
        {
            GameObject towerSpawned;
            towerSpawned = Instantiate(waterTowerPrefab.gameObject, position, Quaternion.identity);

            return towerSpawned;
        }
    }
}