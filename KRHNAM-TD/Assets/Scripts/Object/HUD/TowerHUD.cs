using Abstract;
using Interface;
using UnityEngine;
using UnityEngine.UI;

public class TowerHUD : MonoBehaviour, I_Observer
{
    private Tower tower;
    [SerializeField] private Image strategyImage;

    public void Start()
    {
        tower = this.GetComponentInParent<Tower>();
        tower.Subscribe(this);
        SetStrategyImage();
    }

    void SetStrategyImage()
    {
        if (tower.TowerData.targetingStrategy == null)
        {
            Debug.Log("No strategy");
            return;
        }
        if (tower.TowerData.targetingStrategy.strategySprite == null)
        {
            Debug.Log("No image");
            return;
        }
        strategyImage.sprite = tower.TowerData.targetingStrategy.strategySprite;
    }

    public void UpdateNotify()
    {
        Debug.Log("UpdateNotify");
        SetStrategyImage();
    }
}
