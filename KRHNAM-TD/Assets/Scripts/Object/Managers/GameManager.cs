using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;
    public static GameManager Instance => instance;

    public HudManager HudManager => HudManager.Instance;
    public WaveManager WaveManager => WaveManager.Instance;
    public SoundManager SoundManager => SoundManager.Instance;
    public StoreManager StoreManager => StoreManager.Instance;
    public Grid Grid => Grid.Instance;
    public TowerFactory TowerFactory => TowerFactory.Instance;

    [SerializeField] private List<TowerData> towerDataList;
    [SerializeField] private List<EnemyData> enemyDataList;

    public GameObject Castle { get; private set; }
    public GameObject CastlePrefab;
    public GameObject casteSpawn;

    public bool DebugMode { get; private set; } = false;


    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
            instance = this;

        DontDestroyOnLoad(this.gameObject);
        StartGame();
    }

    public void StartGame()
    {
        SpawnCastle();
        StoreManager.SetDefaultGold();
    }

    public void RestartGame()
    {
        HudManager.Instance.ToggleGameOverMenu();
        KillAllEnemies();
        Destroy(Castle);
        StartGame();
    }

    public void GameOver()
    {
        HudManager.Instance.ToggleGameOverMenu();
    }

    private void SpawnCastle()
    {
        Castle = Instantiate(CastlePrefab, casteSpawn.transform.position, Quaternion.identity);
        Castle castle = Castle.GetComponent<Castle>();
        castle.Hp = 300;
    }

    private void KillAllEnemies()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (var enemy in enemies)
        {
            Destroy(enemy);
        }
    }
    public TowerData GetTowerData(Element element, TowerLevel level)
    {
        foreach (var tower in towerDataList)
        {
            if (tower.Element == element && tower.Level == level)
            {
                return tower;
            }
        }
        return null;
    }

    public EnemyData GetEnemyData(Element element, EnemyType type)
    {
        foreach (var enemyData in enemyDataList)
        {
            if (enemyData.element == element && enemyData.type == type)
            {
                return enemyData;
            }
        }
        return null;
    }
}


