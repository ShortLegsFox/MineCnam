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
        if (tower.targetingStrategy == null)
        {
            Debug.Log("No strategy");
            return;
        }
        if (tower.targetingStrategy.strategySprite == null)
        {
            Debug.Log("No image");
            return;
        }
        Debug.Log(tower.targetingStrategy.strategySprite.ToString());
        strategyImage.sprite = tower.targetingStrategy.strategySprite;
    }

    public void UpdateNotify()
    {
        Debug.Log("UpdateNotify");
        SetStrategyImage();
    }
}
