using Interface;
using System.Collections.Generic;
using TDObject;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    private static TowerFactory instance = null;
    public static TowerFactory Instance => instance;
    [SerializeField] private List<TowerData> towerDataList;

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

    public TowerData GetTowerData(Element element, TowerLevel level)
    {
        foreach (var tower in towerDataList)
        {
            if (tower.Element == element && tower.Level == level)
            {
                return tower;
            }
        }
        return null;
    }

    public static I_TowerFactory GetTowerFactory(Element element)
    {
        switch (element)
        {
            case Element.Fire:
                return new FireTowerFactory();
            case Element.Water:
                return new WaterTowerFactory();
            default:
                return null;
        }
    }
}
