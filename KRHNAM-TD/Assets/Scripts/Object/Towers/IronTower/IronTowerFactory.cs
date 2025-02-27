using Abstract;
using Interface;
using UnityEngine;

namespace TDObject
{
    public class IronTowerFactory : I_TowerFactory
    {
        public Tower CreateBasicTower()
        {
            GameObject prefab = GameManager.Instance.GetTowerData(Element.Metal, TowerLevel.Basic).Prefab;
            GameObject instance = Object.Instantiate(prefab, new Vector3(0, -100, 0), Quaternion.identity);
            instance.transform.parent = Grid.Instance.transform;
            return instance.GetComponent<Tower>();
        }

        public Tower CreateAdvancedTower()
        {
            GameObject prefab = GameManager.Instance.GetTowerData(Element.Metal, TowerLevel.Advanced).Prefab;
            GameObject instance = Object.Instantiate(prefab, new Vector3(0, -100, 0), Quaternion.identity);
            instance.transform.parent = Grid.Instance.transform;
            return instance.GetComponent<Tower>();
        }

        public Tower CreateUltimateTower()
        {
            GameObject prefab = GameManager.Instance.GetTowerData(Element.Metal, TowerLevel.Ultimate).Prefab;
            GameObject instance = Object.Instantiate(prefab, new Vector3(0, -100, 0), Quaternion.identity);
            instance.transform.parent = Grid.Instance.transform;
            return instance.GetComponent<Tower>();
        }
    }
}