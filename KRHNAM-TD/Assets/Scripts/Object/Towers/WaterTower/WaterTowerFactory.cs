using Abstract;
using Interface;
using UnityEngine;

namespace TDObject
{
    public class WaterTowerFactory : I_TowerFactory
    {
        public Tower CreateTower(TowerLevel level)
        {
            GameObject prefab = TowerFactory.Instance.GetTowerData(Element.Water, level).Prefab;
            GameObject instance = Object.Instantiate(prefab, new Vector3(0, -100, 0), Quaternion.identity);
            return instance.GetComponent<Tower>();
        }
    }
}