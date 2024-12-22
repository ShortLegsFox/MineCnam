using Interface;
using UnityEngine;

public class HudManager : MonoBehaviour
{
    private static HudManager instance = null;
    public static HudManager Instance => instance;
    public Texture2D plusCursor;

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

    private void Update()
    {
        PlaceEntity();
        DisplayCursor();
    }

    public void SelectEntity(I_Tower entity)
    {
        EditorManager.Instance.selectedEntityPrefab = entity;
        ErrorManager.DebugLog($"Entity {EditorManager.Instance.selectedEntityPrefab.name} selected for placement.");
    }


    public void PlaceEntity()
    {
        if (Input.GetMouseButtonDown(0) && EditorManager.Instance.IsEntitySelected)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                EditorManager.Instance.PlaceEntity(hit.point);
            }
        }
    }

    public void DisplayCursor()
    {
        if (EditorManager.Instance.IsEntitySelected)
            DisplayBuildCursor();
        else
            DisplayNormalCursor();
    }

    public void DisplayBuildCursor()
    {
        Cursor.SetCursor(plusCursor, Vector2.zero, CursorMode.Auto);
    }

    public void DisplayNormalCursor()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }



}
