using Abstract;
using UnityEngine;

public class FireEnemyFactory : I_EnemyFactory
{
    
    public Enemy CreateEnemy(EnemyType type)
    {      
        GameObject prefab = GameManager.Instance.GetEnemyData(Element.Fire, type).Prefab;
        GameObject instance = Object.Instantiate(prefab, new Vector3(0, -100, 0), Quaternion.identity);
        instance.transform.parent = Grid.Instance.transform;
        return instance.GetComponent<Enemy>();    
    }
    /*
    GameObject prefab = GameManager.Instance.GetTowerData(Element.Water, level).Prefab;
    GameObject instance = Object.Instantiate(prefab, new Vector3(0, -100, 0), Quaternion.identity);
    instance.transform.parent = Grid.Instance.transform;
            return instance.GetComponent<Tower>();
    */

}

