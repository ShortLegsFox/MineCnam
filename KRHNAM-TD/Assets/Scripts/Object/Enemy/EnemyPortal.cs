
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyPortal : MonoBehaviour
{
    private List<GameObject> enemyPrefabList;

    [SerializeField] private float minimumSpawnTime;
    [SerializeField] private float maximumSpawnTime;
    int waveNumber = 1;
    private int listIndex = 0;

    public List<I_EnemyFactory> enemyFactoryList = new List<I_EnemyFactory>();

    void Awake()
    {
        enemyFactoryList.Add(new FireEnemyFactory(GameManager.Instance, Grid.Instance));
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

            yield return StartCoroutine(SetDifficultyLevelOfWave(randomType, waveNumber, nbEnemy));

            waveNumber++;
            yield return StartCoroutine(WaitForNewWave());
        }
    }

    private IEnumerator WaitForEnemiesToSpawn()
    {
        float timeUntilSpawn = Random.Range(minimumSpawnTime, maximumSpawnTime);
        yield return new WaitForSeconds(timeUntilSpawn);
    }

    private void AdjustEnemiesSpawnTimeForWave()
    {

        maximumSpawnTime = maximumSpawnTime/waveNumber < 0.5f ? 0.5f: maximumSpawnTime / waveNumber ;        
    }

    private int GetRandomEnemyType()
    {
        return Random.Range(0, enemyFactoryList.Count);
    }

    private IEnumerator SetDifficultyLevelOfWave(int randomType, int waveNumber, int nbEnemy)
    {
        if (waveNumber < 3)
        {
            yield return StartCoroutine(CreateEasyWave(randomType, nbEnemy));
        }
        else if (waveNumber < 5)
        {
            yield return StartCoroutine(CreateIntermediateWave(randomType, nbEnemy));
        }
        else
        {
            yield return StartCoroutine(CreateHardWave(randomType, nbEnemy));
        }
    }

    private IEnumerator CreateEasyWave(int randomType, int nbEnemy)
    {
        for (int i = 0; i < nbEnemy; i++)
        {
            var facto = new FireEnemyFactory(GameManager.Instance, Grid.Instance);
            //enemyFactoryList[randomType].CreateEnemy(EnemyType.Walking);
            facto.CreateEnemy(EnemyType.Walking, this.transform);
            yield return WaitForEnemiesToSpawn();
        }
    }

    private IEnumerator CreateIntermediateWave(int randomType, int nbEnemy)
    {
        for (int i = 0; i <= nbEnemy; i++)
        {
            int temp = Random.Range(1, 3);
            if (temp == 1)
            {
                enemyFactoryList[randomType].CreateEnemy(EnemyType.Walking);
            }
            else
            {
                enemyFactoryList[randomType].CreateEnemy(EnemyType.Flying);
            }
            yield return WaitForEnemiesToSpawn();
        }
    }

    private IEnumerator CreateHardWave(int randomType, int nbEnemy)
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
            yield return WaitForEnemiesToSpawn();
        }
    }

    private IEnumerator WaitForNewWave()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        int timeBetweenWavesInSeconds = 15;
        int timeBetweenEmptyWaveCheck = 1;
        
        while (!enemies.All(element => element == null))
        {         
            yield return new WaitForSeconds(timeBetweenEmptyWaveCheck);
        }
        
        yield return new WaitForSeconds(timeBetweenWavesInSeconds);
    }
}