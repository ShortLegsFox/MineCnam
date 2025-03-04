using Abstract;
using Interface;
using UnityEngine;

public class BasicTowerState : I_TowerUpgradeState
{
    public void Upgrade(Tower tower)
    {
        if (tower is BasicTower && StoreManager.Instance.CanAfford(tower.TowerData.UpgradeCost))
        {
            StoreManager.Instance.RemoveGold(tower.TowerData.UpgradeCost);
            I_TowerFactory factory = TowerFactory.GetTowerFactory(tower.TowerData.Element);
            Vector3 position = tower.transform.position;
            Case caseTower = tower.Position;
            tower.Destroy();
            Tower newTower = factory.CreateAdvancedTower(position);
            caseTower.PlaceEntity(newTower);
            newTower.isPlaced = true;
            newTower.SetEntityAsObstacle();
        }
    }
}
