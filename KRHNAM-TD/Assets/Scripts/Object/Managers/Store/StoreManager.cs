using Abstract;
using Interface;
using System.Collections;
using UnityEngine;

public class StoreManager : MonoBehaviour
{
    private static StoreManager instance = null;
    public static StoreManager Instance => instance;
    public int gold = 0;
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

        DontDestroyOnLoad(this.gameObject);
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
            Tower tower = towerFactory.CreateTower(article.Level);
            EditorManager.Instance.selectedEntity = tower;
            return true;
        }

        else
        {
            Debug.Log("Not enough gold to buy " + article.Name);
            return false;
        }
    }


}
