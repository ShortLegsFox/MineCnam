using UnityEngine;

public class FireEnemyFactory : I_EnemyFactory
{
    public GameObject portal;
    public Enemy CreateEnemy(EnemyType type)
    {
        portal = GameObject.Find("Portal");
        EnemyData enemyData = GameManager.Instance.GetEnemyData(Element.Fire, type);
        GameObject prefab = enemyData.Prefab;
        GameObject instance = Object.Instantiate(prefab, portal.transform.position, Quaternion.identity);
        instance.transform.parent = Grid.Instance.transform;
        return instance.GetComponent<Enemy>();
    }
}