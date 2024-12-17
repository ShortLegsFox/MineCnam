using UnityEngine;

public class HudManager : MonoBehaviour
{
    private static HudManager instance = null;
    public static HudManager Instance => instance;

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
