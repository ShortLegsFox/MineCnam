using Abstract;
using Interface;
using UnityEngine;

namespace TDObject
{
    public class IronTowerFactory : I_TowerFactory
    {
        public Tower CreateTower(TowerLevel level)
        {
            GameObject prefab = GameManager.Instance.GetTowerData(Element.Metal, level).Prefab;
            GameObject instance = Object.Instantiate(prefab, new Vector3(0, -100, 0), Quaternion.identity);
            instance.transform.parent = Grid.Instance.transform;
            return instance.GetComponent<Tower>();
        }
    }
}