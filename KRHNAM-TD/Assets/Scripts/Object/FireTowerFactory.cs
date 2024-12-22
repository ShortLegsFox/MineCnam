using Interface;
using UnityEngine;

namespace Object
{
    public class FireTowerFactory : MonoBehaviour, I_TowerFactory
    {
        public FireTower fireTowerPrefab;

        public GameObject CreateTower(Vector3 position)
        {
            GameObject towerSpawned;
            towerSpawned = Instantiate(fireTowerPrefab.gameObject, position, Quaternion.identity);

            return towerSpawned;
        }
    }
}