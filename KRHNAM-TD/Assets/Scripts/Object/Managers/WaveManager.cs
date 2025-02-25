using UnityEngine;

public class WaveManager : MonoBehaviour
{
    private static WaveManager instance = null;
    public static WaveManager Instance => instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
            instance = this;

    }
}
