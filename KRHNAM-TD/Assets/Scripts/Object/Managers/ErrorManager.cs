using UnityEngine;

public static class ErrorManager
{
    public static void LogError(string message)
    {
        Debug.LogError(message);
    }

    public static void LogWarning(string message)
    {
        Debug.LogWarning(message);
    }

    public static void LogInfo(string message)
    {
        Debug.Log(message);
    }

    public static void DebugLog(string message)
    {
        if (GameManager.Instance.DebugMode)
        {
            Debug.Log(message);
        }
    }
}
