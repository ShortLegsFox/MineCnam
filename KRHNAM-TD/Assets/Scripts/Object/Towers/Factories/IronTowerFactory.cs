using Abstract;
using Interface;
using UnityEngine;

namespace TDObject
{
    public class IronTowerFactory : I_TowerFactory
    {
        public Tower CreateBasicTower(Vector3? position = null)
        {
            Vector3 newPosition = new Vector3(0, -100, 0);

            if (position != null)
            {
                newPosition = (Vector3)position;
            }

            GameObject prefab = GameManager.Instance.GetTowerData(Element.Metal, TowerLevel.Basic).Prefab;
            GameObject instance = Object.Instantiate(prefab, newPosition, Quaternion.identity);
            instance.transform.parent = Grid.Instance.transform;
            return instance.GetComponent<Tower>();
        }

        public Tower CreateAdvancedTower(Vector3? position = null)
        {
            Vector3 newPosition = new Vector3(0, -100, 0);

            if (position != null)
            {
                newPosition = (Vector3)position;
            }
            GameObject prefab = GameManager.Instance.GetTowerData(Element.Metal, TowerLevel.Advanced).Prefab;
            GameObject instance = Object.Instantiate(prefab, newPosition, Quaternion.identity);
            instance.transform.parent = Grid.Instance.transform;
            return instance.GetComponent<Tower>();
        }

        public Tower CreateUltimateTower(Vector3? position = null)
        {
            Vector3 newPosition = new Vector3(0, -100, 0);

            if (position != null)
            {
                newPosition = (Vector3)position;
            }
            GameObject prefab = GameManager.Instance.GetTowerData(Element.Metal, TowerLevel.Ultimate).Prefab;
            GameObject instance = Object.Instantiate(prefab, newPosition, Quaternion.identity);
            instance.transform.parent = Grid.Instance.transform;
            return instance.GetComponent<Tower>();
        }
    }
}