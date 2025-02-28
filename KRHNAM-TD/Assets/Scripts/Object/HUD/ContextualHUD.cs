using UnityEngine;
using UnityEngine.UI;

public class ContextualHUD : MonoBehaviour
{
    public GameObject ContextualPannel;

    public Button firstStrategyButton;
    public Button closestStrategyButton;
    public Button lowestStrategyButton;
    public Button upgradeButton;

    void Update()
    {
        if (EditorManager.Instance.contextualTower != null)
        {
            ContextualPannel.SetActive(true);
            HighlightCurrentStrategy();
            UpgradeAvailable();
        }
        else
        {
            ContextualPannel.SetActive(false);
        }
    }

    public void UpgradeTower()
    {
        EditorManager.Instance.contextualTower.Upgrade();
    }


    void HighlightCurrentStrategy()
    {
        if (EditorManager.Instance.contextualTower.TowerData.targetingStrategy.GetType() == typeof(FirstEnemyStrategySO))
        {
            firstStrategyButton.interactable = false;
            closestStrategyButton.interactable = true;
            lowestStrategyButton.interactable = true;
        }
        else if (EditorManager.Instance.contextualTower.TowerData.targetingStrategy.GetType() == typeof(NearestEnemyStrategySO))
        {
            firstStrategyButton.interactable = true;
            closestStrategyButton.interactable = false;
            lowestStrategyButton.interactable = true;
        }
        else if (EditorManager.Instance.contextualTower.TowerData.targetingStrategy.GetType() == typeof(LowestHealthStrategySO))
        {
            firstStrategyButton.interactable = true;
            closestStrategyButton.interactable = true;
            lowestStrategyButton.interactable = false;
        }
    }


    void UpgradeAvailable()
    {
        if (EditorManager.Instance.contextualTower.TowerData.UpgradeCost != 0)
        {
            int upgradeCost = (int)EditorManager.Instance.contextualTower.TowerData.UpgradeCost;
            if (StoreManager.Instance.CanAfford(upgradeCost))
                upgradeButton.interactable = true;
            else
                upgradeButton.interactable = false;
        }
        else
            upgradeButton.interactable = false;
    }

}
