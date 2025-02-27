using Interface;
using System.Collections;
using UnityEngine;

public class StoreManager : MonoBehaviour
{
    private static StoreManager instance = null;
    public static StoreManager Instance => instance;
    public int gold = 0;
    public int DefaultGoldAmount = 100;
    public int IncrementGoldAmount = 1;
    public float IncrementGoldInterval = 1;
    public StoreArticle[] StoreArticles;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
            instance = this;

        SetDefaultGold();
    }

    private void Start()
    {
        StartCoroutine(IncrementGold());
    }

    IEnumerator IncrementGold()
    {
        while (true)
        {
            AddGold(IncrementGoldAmount);
            yield return new WaitForSeconds(IncrementGoldInterval);
        }
    }

    public void AddGold(int amount)
    {
        gold += amount;
    }

    public void RemoveGold(int amount)
    {
        gold -= amount;
    }

    public bool CanAfford(StoreArticle article)
    {
        return gold >= article.Price;
    }

    public bool Buy(StoreArticle article)
    {
        if (CanAfford(article))
        {
            RemoveGold(article.Price);
            I_TowerFactory towerFactory = TowerFactory.GetTowerFactory(article.Element);
            Entity tower = null;

            switch (article.Level)
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
            return true;
        }

        else
        {
            Debug.Log("Not enough gold to buy " + article.Name);
            return false;
        }
    }


    public void SetDefaultGold()
    {
        gold = DefaultGoldAmount;
    }


}
