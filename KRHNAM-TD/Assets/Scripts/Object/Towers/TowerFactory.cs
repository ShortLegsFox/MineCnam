using Interface;
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
            case Element.Wood:
                return new WoodTowerFactory();
            case Element.Metal:
                return new IronTowerFactory();
            case Element.Earth:
                return new EarthTowerFactory();
            default:
                throw new System.Exception("Tower factory not implemented");
        }
    }
}