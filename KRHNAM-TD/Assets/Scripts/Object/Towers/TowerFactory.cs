using Interface;
using System.Collections.Generic;
using TDObject;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    private static TowerFactory instance = null;
    public static TowerFactory Instance => instance;

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