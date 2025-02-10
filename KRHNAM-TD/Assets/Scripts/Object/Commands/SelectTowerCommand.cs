using Interface;

public class SelectTowerCommand : I_Command
{
    private TowerData towerData;

    public SelectTowerCommand(TowerData towerData)
    {
        this.towerData = towerData;
    }

    public void Execute()
    {
        I_TowerFactory towerFactory = TowerFactory.GetTowerFactory(towerData.Element);
        Entity tower = towerFactory.CreateTower(towerData.Level);
        EditorManager.Instance.selectedEntity = tower;
        ErrorManager.DebugLog($"Entity selected for placement.");
    }
}