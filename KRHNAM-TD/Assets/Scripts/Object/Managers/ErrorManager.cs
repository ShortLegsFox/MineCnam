using UnityEngine;

public static class ErrorManager
{
    public static void DebugLog(string message)
    {
        if (GameManager.Instance.DebugMode)
        {
            Debug.Log(message);
        }
    }
}
