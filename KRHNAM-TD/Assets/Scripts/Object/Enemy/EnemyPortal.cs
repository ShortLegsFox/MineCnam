using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPortal : MonoBehaviour
{
    private List<GameObject> enemyPrefabList;

    [SerializeField] private float minimumSpawnTime;
    [SerializeField] private float maximumSpawnTime;
    private int listIndex = 0;

    public List<I_EnemyFactory> enemyFactoryList = new List<I_EnemyFactory>();

    void Awake()
    {
        enemyFactoryList.Add(new FireEnemyFactory());
        enemyFactoryList.Add(new WaterEnemyFactory());
        enemyFactoryList.Add(new MetalEnemyFactory());
        enemyFactoryList.Add(new WoodEnemyFactory());
        enemyFactoryList.Add(new EarthEnemyFactory());

        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            float timeUntilSpawn = Random.Range(minimumSpawnTime, maximumSpawnTime);
            yield return new WaitForSeconds(timeUntilSpawn);

            enemyFactoryList[listIndex].CreateEnemy(EnemyType.Flying);
            enemyFactoryList[listIndex].CreateEnemy(EnemyType.Walking);
            enemyFactoryList[listIndex].CreateEnemy(EnemyType.Bulking);

            listIndex = (listIndex + 1) % enemyFactoryList.Count;
        }
    }

}
