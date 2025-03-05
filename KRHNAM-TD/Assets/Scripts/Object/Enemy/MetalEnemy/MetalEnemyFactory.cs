using UnityEngine;

public class MetalEnemyFactory : I_EnemyFactory
{
    public GameObject portal;
    public Enemy CreateEnemy(EnemyType type)
    {
        portal = GameObject.Find("Portal");
        GameObject prefab = GameManager.Instance.GetEnemyData(Element.Metal, type).Prefab;
        GameObject instance = Object.Instantiate(prefab, portal.transform.position, Quaternion.Euler(0, 90, 0));
        instance.transform.parent = Grid.Instance.transform;
        return instance.GetComponent<Enemy>();
    }
    
    public Enemy CreateEnemy(EnemyType type, Transform spawnPoint)
    {
        return null;
    }
}