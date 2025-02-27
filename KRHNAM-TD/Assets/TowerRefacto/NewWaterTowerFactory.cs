using Abstract;
using Interface;
using UnityEngine;

public class NewWaterTowerFactory : MonoBehaviour, I_NewWaterTowerFactory
{
    public Tower CreateBasicTower()
    {
        GameObject prefab = GameManager.Instance.GetTowerData(Element.Water, TowerLevel.Basic).Prefab;
        GameObject instance = Object.Instantiate(prefab, new Vector3(0, -100, 0), Quaternion.identity);
        instance.transform.parent = Grid.Instance.transform;
        return instance.GetComponent<Tower>();
    }

    public Tower CreateAdvancedTower()
    {
        GameObject prefab = GameManager.Instance.GetTowerData(Element.Water, TowerLevel.Advanced).Prefab;
        GameObject instance = Object.Instantiate(prefab, new Vector3(0, -100, 0), Quaternion.identity);
        instance.transform.parent = Grid.Instance.transform;
        return instance.GetComponent<Tower>();
    }

    public Tower CreateUltimateTower()
    {
        GameObject prefab = GameManager.Instance.GetTowerData(Element.Water, TowerLevel.Ultimate).Prefab;
        GameObject instance = Object.Instantiate(prefab, new Vector3(0, -100, 0), Quaternion.identity);
        instance.transform.parent = Grid.Instance.transform;
        return instance.GetComponent<Tower>();
    }
}
