using Abstract;
using Interface;
using UnityEngine;

namespace TDObject
{
    public class FireTowerFactory : I_TowerFactory
    {
        public Tower CreateTower(TowerLevel level)
        {
            GameObject prefab = TowerFactory.Instance.GetTowerData(Element.Fire, level).Prefab;
            GameObject instance = Object.Instantiate(prefab, new Vector3(0, -100, 0), Quaternion.identity);
            return instance.GetComponent<Tower>();
        }
    }
}
