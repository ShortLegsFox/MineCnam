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

    [SerializeField] private Grid grid;

    [SerializeField] private List<TowerData> towerDataList;
    [SerializeField] private List<EnemyData> enemyDataList;

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
    }

    public void Start()
    {
        SoundManager.PlayMusic("MC1");
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            DebugMode = !DebugMode;
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            HudManager.ToggleStorePannel();
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
}
