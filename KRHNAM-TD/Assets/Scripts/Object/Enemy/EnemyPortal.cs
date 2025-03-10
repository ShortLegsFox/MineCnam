
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Interface;

public class EnemyPortal : MonoBehaviour
{
    [SerializeField] private float minimumSpawnTime;
    [SerializeField] private float maximumSpawnTime;
    public int waveNumber { get; private set; } = 1;

    public List<I_EnemyFactory> enemyFactoryList = new List<I_EnemyFactory>();

    void Start()
    {
        enemyFactoryList.Add(new FireEnemyFactory(GameManager.Instance, Grid.Instance));
        enemyFactoryList.Add(new WaterEnemyFactory(GameManager.Instance, Grid.Instance));
        enemyFactoryList.Add(new MetalEnemyFactory(GameManager.Instance, Grid.Instance));
        enemyFactoryList.Add(new WoodEnemyFactory(GameManager.Instance, Grid.Instance));
        enemyFactoryList.Add(new EarthEnemyFactory(GameManager.Instance, Grid.Instance));

        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            int nbEnemy = waveNumber * 4;

            AdjustEnemiesSpawnTimeForWave();
            int randomType = GetRandomEnemyType();

            yield return StartCoroutine(SetDifficultyLevelOfWave(randomType, waveNumber, nbEnemy));

            yield return StartCoroutine(WaitForNewWave());
        }
    }

    public void ResetWaveNumber()
    {
        waveNumber = 1;
    }

    private void NextWave()
    {
        waveNumber++;
        HudManager.Instance.UpdateWaveText(waveNumber);
    }

    private IEnumerator WaitForEnemiesToSpawn()
    {
        float timeUntilSpawn = Random.Range(minimumSpawnTime, maximumSpawnTime);
        yield return new WaitForSeconds(timeUntilSpawn);
    }

    private void AdjustEnemiesSpawnTimeForWave()
    {

        maximumSpawnTime = maximumSpawnTime / waveNumber < 0.5f ? 0.5f : maximumSpawnTime / waveNumber;
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
            enemyFactoryList[randomType].CreateEnemy(EnemyType.Walking, this.transform);
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
                enemyFactoryList[randomType].CreateEnemy(EnemyType.Walking, this.transform);
            }
            else
            {
                enemyFactoryList[randomType].CreateEnemy(EnemyType.Flying, this.transform);
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
                enemyFactoryList[randomType].CreateEnemy(EnemyType.Walking, this.transform);
            }
            else if (temp == 2)
            {
                enemyFactoryList[randomType].CreateEnemy(EnemyType.Flying, this.transform);
            }
            else
            {
                enemyFactoryList[randomType].CreateEnemy(EnemyType.Bulking, this.transform);
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
        NextWave();
        yield return new WaitForSeconds(timeBetweenWavesInSeconds);
    }
}