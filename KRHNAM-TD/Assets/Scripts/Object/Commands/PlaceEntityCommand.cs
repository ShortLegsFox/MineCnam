using UnityEngine;
using Interface;

public class PlaceEntityCommand : I_Command
{
    private Entity Entity;
    private Case Case;

    public PlaceEntityCommand(Entity entity, Case _case)
    {
        EditorManager.Instance.selectedEntity = entity;
        this.Case = _case;
    }

    public void Execute()
    {
        if (Case != null)
        {
            if (Case.IsEmpty)
            {
                if (EditorManager.Instance.IsEntitySelected && !EditorManager.Instance.selectedEntity.isPlaced)
                {
                    SoundManager.Instance.PlayEffect("Build");
                    Vector3 newObjectPosition = new Vector3(Case.worldPosition.x, Case.worldPosition.y + 1, Case.worldPosition.z);
                    EditorManager.Instance.selectedEntity.OnPlace(newObjectPosition);
                    EditorManager.Instance.selectedEntity.isPlaced = true;
                    EditorManager.Instance.selectedEntity.SetEntityAsObstacle();
                    Case.PlaceEntity(EditorManager.Instance.selectedEntity);
                    EditorManager.Instance.selectedEntity = null;
                    ErrorManager.DebugLog($"Entity placed at [{Case.GridX};{Case.GridY}");
                }
            }
            else
                ErrorManager.DebugLog("Case is not empty.");
        }
        else
            ErrorManager.DebugLog("Invalid position for entity placement.");
    }

}
