using Abstract;
using UnityEngine;

public class WoodEnemyFactory : I_EnemyFactory
{
    public GameObject portal;
    public Enemy CreateEnemy(EnemyType type)
    {
        portal = GameObject.Find("Portal");
        GameObject prefab = GameManager.Instance.GetEnemyData(Element.Wood, type).Prefab;
        GameObject instance = Object.Instantiate(prefab, portal.transform.position, Quaternion.identity);
        instance.transform.parent = Grid.Instance.transform;
        return instance.GetComponent<Enemy>();    
    }
}