using Abstract;
using Interface;
using UnityEngine;

public class AdvancedTowerState : I_TowerUpgradeState
{
    private int _upgradeCost = 100;
    public void Upgrade(Tower tower)
    {
        if (tower is AdvancedTower && StoreManager.Instance.CanAfford(_upgradeCost))
        {
            StoreManager.Instance.RemoveGold(_upgradeCost);
            I_TowerFactory factory = TowerFactory.GetTowerFactory(tower.TowerData.Element);
            Vector3 position = tower.transform.position;
            Case caseTower = tower.Position;
            tower.Destroy();
            Tower newTower = factory.CreateUltimateTower(position);
            caseTower.PlaceEntity(newTower);
            newTower.isPlaced = true;
            newTower.SetEntityAsObstacle();
        }
    }
}
