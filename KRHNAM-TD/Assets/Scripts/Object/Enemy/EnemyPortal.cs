using UnityEngine;
using System.Collections.Generic;

public class EnemyPortal : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemyPrefabList;

    [SerializeField] private float minimumSpawnTime;
    [SerializeField] private float maximumSpawnTime;
    [SerializeField] private float timeUntilSpawn;
    private int listIndex=0;

    public List<I_EnemyFactory> enemyFactoryList = new List<I_EnemyFactory>();


    void Awake()
    {
        enemyFactoryList.Add(new FireEnemyFactory());
        enemyFactoryList.Add(new WaterEnemyFactory());
        enemyFactoryList.Add(new MetalEnemyFactory());
        enemyFactoryList.Add(new WoodEnemyFactory());
        enemyFactoryList.Add(new EarthEnemyFactory());
        SetTimeUntilSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        timeUntilSpawn -= Time.deltaTime;
        if (timeUntilSpawn <= 0)
        {
            //Debug.Log("Spawning enemy at " + transform.position);
            //Instantiate(enemyFactoryList[listIndex].CreateEnemy(EnemyType.Walking), transform.position, Quaternion.identity);
            enemyFactoryList[listIndex].CreateEnemy(EnemyType.Flying);
            enemyFactoryList[listIndex].CreateEnemy(EnemyType.Walking);
            enemyFactoryList[listIndex].CreateEnemy(EnemyType.Bulking);
            SetTimeUntilSpawn();
            listIndex = (listIndex + 1) % 5;
        }
    }

    private void SetTimeUntilSpawn()
    {
        timeUntilSpawn = Random.Range(minimumSpawnTime, maximumSpawnTime);
    }
}
