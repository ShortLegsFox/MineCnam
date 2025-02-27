using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPortal : MonoBehaviour
{
    private List<GameObject> enemyPrefabList;

    [SerializeField] private float minimumSpawnTime;
    [SerializeField] private float maximumSpawnTime;
    int waveNumber = 0;
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
            int nbEnemy = waveNumber * 10;

            WaitForEnemiesToSpawn();
            AdjustEnemiesSpawnTimeForWave();
            int randomType = GetRandomEnemyType();

            CreateEnemyByTypeAndWave(randomType,waveNumber,nbEnemy);

            waveNumber ++;
        }
    }

    private void WaitForEnemiesToSpawn()
    {
        float timeUntilSpawn = Random.Range(minimumSpawnTime, maximumSpawnTime);
        new WaitForSeconds(timeUntilSpawn);
    }

    private void AdjustEnemiesSpawnTimeForWave()
    {
        minimumSpawnTime /= waveNumber;
        maximumSpawnTime /= waveNumber;
    }

    private int GetRandomEnemyType()
    {
        return Random.Range(0, enemyFactoryList.Count);
    }

    private void CreateEnemyByTypeAndWave(int randomType, int waveNumber,int nbEnemy)
    {
        if(waveNumber  < 3)
        {

        }
        else if (waveNumber < 5)
        {

        }
        else
        {

        }
        enemyFactoryList[randomType].CreateEnemy(EnemyType.Flying);
        enemyFactoryList[randomType].CreateEnemy(EnemyType.Walking);
        enemyFactoryList[randomType].CreateEnemy(EnemyType.Bulking);
    }
}