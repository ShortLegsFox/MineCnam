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
        Entity tower = null;

        switch (towerData.Level)
        {
            case TowerLevel.Basic:
                tower = towerFactory.CreateBasicTower();
                break;
            case TowerLevel.Advanced:
                tower = towerFactory.CreateAdvancedTower();
                break;
            case TowerLevel.Ultimate:
                tower = towerFactory.CreateUltimateTower();
                break;
        }

        EditorManager.Instance.selectedEntity = tower;
        ErrorManager.DebugLog($"Entity selected for placement.");
    }
}