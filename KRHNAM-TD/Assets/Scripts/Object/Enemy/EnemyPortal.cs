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

            AdjustEnemiesSpawnTimeForWave();
            int randomType = GetRandomEnemyType();

            SetDifficultyLevelOfWave(randomType,waveNumber,nbEnemy);

            waveNumber ++;
            WaitForNewWave();
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

    private void SetDifficultyLevelOfWave(int randomType, int waveNumber,int nbEnemy)
    {
        if(waveNumber  < 3)
        {
            CreateEasyWave(randomType, nbEnemy);
        }
        else if (waveNumber < 5)
        {
            CreateIntermediateWave(randomType, nbEnemy);
        }
        else
        {
            CreateHardWave(randomType, nbEnemy);
        }
    }

    private void CreateEasyWave(int randomType,int nbEnemy)
    {
        for(int i = 0; i <= nbEnemy; i++)
        {
            enemyFactoryList[randomType].CreateEnemy(EnemyType.Walking);
            WaitForEnemiesToSpawn();
        }
    }

    private void CreateIntermediateWave(int randomType, int nbEnemy)
    {
        for (int i = 0; i <= nbEnemy; i++)
        {
            int temp = Random.Range(1, 3);
            if(temp == 1)
            {
                enemyFactoryList[randomType].CreateEnemy(EnemyType.Walking);
            }
            else
            {
                enemyFactoryList[randomType].CreateEnemy(EnemyType.Flying);
            }
            WaitForEnemiesToSpawn();
        }
    }

    private void CreateHardWave(int randomType, int nbEnemy)
    {
        for (int i = 0; i <= nbEnemy; i++)
        {
            int temp = Random.Range(1, 4);
            if (temp == 1)
            {
                enemyFactoryList[randomType].CreateEnemy(EnemyType.Walking);
            }
            else if (temp == 2) 
            {
                enemyFactoryList[randomType].CreateEnemy(EnemyType.Flying);
            }
            else
            {
                enemyFactoryList[randomType].CreateEnemy(EnemyType.Bulking);
            }
            WaitForEnemiesToSpawn();
        }
    }

    private void WaitForNewWave()
    {
        int timeBetweenWavesInSeconds = 15;
        new WaitForSeconds(timeBetweenWavesInSeconds);
    }
}