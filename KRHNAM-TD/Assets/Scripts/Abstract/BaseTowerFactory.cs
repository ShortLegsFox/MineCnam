using Abstract;
using Interface;
using UnityEngine;

public abstract class BaseTowerFactory : I_TowerFactory
{
    protected abstract Element ElementType { get; }

    public Tower CreateBasicTower(Vector3? position = null)
    {
        return CreateTower(TowerLevel.Basic, position);
    }
    
    public Tower CreateAdvancedTower(Vector3? position = null)
    {
        return CreateTower(TowerLevel.Advanced, position);
    }
    
    public Tower CreateUltimateTower(Vector3? position = null)
    {
        return CreateTower(TowerLevel.Ultimate, position);
    }

    private Tower CreateTower(TowerLevel towerLevel, Vector3? position = null)
    {
        Vector3 newPosition = position ?? new Vector3(0, -100, 0);

        GameObject prefab = GameManager.Instance.GetTowerData(ElementType, towerLevel).Prefab;
        GameObject instance = Object.Instantiate(prefab, newPosition, Quaternion.identity);
        instance.transform.parent = Grid.Instance.transform;
        return instance.GetComponent<Tower>();
    }
}
