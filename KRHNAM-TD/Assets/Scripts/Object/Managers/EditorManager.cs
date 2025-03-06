using Abstract;
using UnityEngine;

public class EditorManager : MonoBehaviour
{
    private static EditorManager instance = null;
    public static EditorManager Instance => instance;

    public Entity selectedEntity;
    public bool IsEntitySelected => selectedEntity != null;

    public Tower contextualTower;
    [SerializeField] private TargetingStrategySO firstStrategy, nearestStrategy, lowestStrategy;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
            instance = this;

    }


    public void SelectTower(TowerData towerData)
    {
        I_Command selectTowerCommand = new SelectTowerCommand(towerData);
        selectTowerCommand.Execute();
    }

    public void SetContextualTower(Tower tower)
    {
        contextualTower = tower;
        Debug.Log("Contextual Tower Set");
    }

    public void ClearContextualTower()
    {
        contextualTower = null;
    }

    public void PlaceEntity(Case selectedCell)
    {
        var command = new PlaceEntityCommand(selectedEntity, selectedCell);
        command.Execute();
    }

    public void SetFirstStategy()
    {
        contextualTower.SetStrategy(firstStrategy);
    }

    public void SetClosestStrategy()
    {
        contextualTower.SetStrategy(nearestStrategy);
    }

    public void SetLowHpStrategy()
    {
        contextualTower.SetStrategy(lowestStrategy);
    }
}
