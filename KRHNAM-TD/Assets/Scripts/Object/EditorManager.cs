using UnityEngine;

public class EditorManager : MonoBehaviour
{
    private static EditorManager instance = null;
    public static EditorManager Instance => instance;

    public Entity selectedEntityPrefab;
    public bool IsEntitySelected => selectedEntityPrefab != null;


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


    public void PlaceEntity(Vector3 position)
    {
        if (selectedEntityPrefab != null)
        {
            ErrorManager.DebugLog($"Placing entity {selectedEntityPrefab.name} at {position}");
            var command = new PlaceEntityCommand(selectedEntityPrefab, position);
            command.Execute();
        }
        else
            ErrorManager.DebugLog("No entity selected for placement.");
    }


}
