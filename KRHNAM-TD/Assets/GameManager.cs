using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;
    public static GameManager Instance => instance;

    public HudManager HudManager => HudManager.Instance;
    public WaveManager WaveManager => WaveManager.Instance;
    public SoundManager SoundManager => SoundManager.Instance;


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
}
