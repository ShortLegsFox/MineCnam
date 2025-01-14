using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    private static CursorManager instance = null;
    public static CursorManager Instance => instance;

    public List<Texture2D> Cursors;


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

    public void Update()
    {
        DisplayCursor();
    }


    public void DisplayCursor()
    {
        if (EditorManager.Instance.IsEntitySelected && Grid.Instance.selectedCase != null && Grid.Instance.selectedCase.IsEmpty)
            SetCursor("PlusCursor");
        else if (EditorManager.Instance.IsEntitySelected && Grid.Instance.selectedCase != null && !Grid.Instance.selectedCase.IsEmpty)
            SetCursor("BlockedCursor");
        else if (EditorManager.Instance.IsEntitySelected && Grid.Instance.selectedCase == null)
            SetCursor("BlockedCursor");
        else
            SetDefaultCursor();
    }

    private void SetCursor(string name)
    {
        foreach (var cursor in Cursors)
        {
            if (cursor.name == name)
            {
                Cursor.SetCursor(cursor, Vector2.zero, CursorMode.Auto);
                return;
            }
        }
    }

    public void SetBlockedCursor()
    {
        SetCursor("BlockedCursor");
    }

    public void SetDefaultCursor()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

}
