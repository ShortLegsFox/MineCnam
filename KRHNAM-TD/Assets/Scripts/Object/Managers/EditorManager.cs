using UnityEngine;

public class EditorManager : MonoBehaviour
{
    private static EditorManager instance = null;
    public static EditorManager Instance => instance;

    public Entity selectedEntity;
    public bool IsEntitySelected => selectedEntity != null;

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

    public void PlaceEntity(Case selectedCell)
    {
        if (selectedEntity != null && selectedCell != null)
        {
            var command = new PlaceEntityCommand(selectedEntity, selectedCell);
            command.Execute();
        }
        else
            ErrorManager.DebugLog("No entity selected for placement.");
    }
}
