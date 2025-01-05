using UnityEngine;

public class PlaceEntityCommand : I_Command
{
    private Entity Entity;  // L�entit� � poser
    private Case Case;

    public PlaceEntityCommand(Entity entity, Case _case)
    {
        this.Entity = entity;
        this.Case = _case;
    }

    public void Execute()
    {
        if (Case != null)
        {
            if (Case.IsEmpty)
            {
                Vector3 newObjectPosition = new Vector3(Case.worldPosition.x, Case.worldPosition.y + 1, Case.worldPosition.z);
                EditorManager.Instance.selectedEntity.OnPlace(newObjectPosition);
                EditorManager.Instance.selectedEntity.isPlaced = true;
                Case.entity = EditorManager.Instance.selectedEntity;
                EditorManager.Instance.selectedEntity = null;
                ErrorManager.DebugLog($"Entity placed at [{Case.GridX};{Case.GridY}");
            }
            else
                ErrorManager.DebugLog("Case is not empty.");
        }
        else
            ErrorManager.DebugLog("Invalid position for entity placement.");
    }

}
