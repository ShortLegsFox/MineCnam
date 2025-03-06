using System.Collections.Generic;
using TDObject.HUD;
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
    public EnemyPortal enemyPortal;

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

        StartGame();

    }

    public void StartGame()
    {
        SpawnCastle();
        StoreManager.SetDefaultGold();
        enemyPortal.ResetWaveNumber();
        Time.timeScale = 1;
    }

    public void RestartGame()
    {
        if (HudManager.Instance.GameOverMenu.activeSelf)
            HudManager.Instance.ToggleGameOverMenu();
        if (HudManager.Instance.PauseMenu.activeSelf)
            HudManager.Instance.TogglePauseMenu();


        SaveScore();
        KillAllEnemies();
        KillAllTowers();
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

    private void KillAllTowers()
    {
        GameObject[] towers = GameObject.FindGameObjectsWithTag("Tower");
        foreach (var tower in towers)
        {
            Destroy(tower);
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


    public void SaveScore()
    {
        Debug.Log("Score saved with wave: " + enemyPortal.waveNumber + "(" + HudManager.Instance.playerName + ")");
        Score score = new Score(HudManager.Instance.playerName, enemyPortal.waveNumber);


        ScoreList scoreList = PlayerPrefs.HasKey("Scores") ?
        JsonUtility.FromJson<ScoreList>(PlayerPrefs.GetString("Scores")) :
        new ScoreList();


        scoreList.scores.Add(score);
        string json = JsonUtility.ToJson(scoreList);
        PlayerPrefs.SetString("Scores", json);
        PlayerPrefs.Save();
    }


    public void AccelereGame()
    {
        Time.timeScale = 10;
    }

}


