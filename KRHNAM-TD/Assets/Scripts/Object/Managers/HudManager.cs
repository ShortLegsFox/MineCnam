using Abstract;
using Interface;
using UnityEngine;

public class HudManager : MonoBehaviour
{
    private static HudManager instance = null;
    public static HudManager Instance => instance;
    public static Entity selectedEntity;
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
        DrawScope();
        OnEntityHover();
    }

    public void SelectTower(TowerData towerData)
    {
        I_TowerFactory towerFactory = TowerFactory.GetTowerFactory(towerData.Element);
        Entity tower = towerFactory.CreateTower(towerData.Level);
        EditorManager.Instance.selectedEntity = tower;

        ErrorManager.DebugLog($"Entity selected for placement.");
    }

    public void PlaceEntity()
    {
        if (Input.GetMouseButtonDown(0) && EditorManager.Instance.IsEntitySelected && !EditorManager.Instance.selectedEntity.isPlaced)
        {
            Debug.Log("Placing entity");

            EditorManager.Instance.PlaceEntity(Grid.Instance.selectedCase);
        }
    }

    public void DrawScope()
    {
        Entity entity = EditorManager.Instance.selectedEntity != null ? EditorManager.Instance.selectedEntity : selectedEntity;
        if (entity is Tower tower)
        {
            float angleStep = 360f / 100; // Angle entre chaque point
            Vector3 previousPoint = tower.Position.worldPosition + new Vector3(tower.towerData.Range, 0, 0); // Premier point sur le cercle

            for (int i = 1; i <= 100; i++)
            {
                float angle = Mathf.Deg2Rad * (i * angleStep);
                Vector3 nextPoint = tower.Position.worldPosition + new Vector3(Mathf.Cos(angle) * tower.towerData.Range, 0, Mathf.Sin(angle) * tower.towerData.Range);

                Debug.DrawLine(previousPoint, nextPoint, Color.gray); // Dessine une ligne entre les points
                previousPoint = nextPoint;
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

    public void OnEntityHover()
    {
        Entity entity = Grid.Instance.selectedCase?.entity;
        if (entity != null)
            selectedEntity = entity;
        else
            selectedEntity = null;
    }



}
