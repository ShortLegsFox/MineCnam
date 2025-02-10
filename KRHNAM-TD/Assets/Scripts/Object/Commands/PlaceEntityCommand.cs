using UnityEngine;

public class PlaceEntityCommand : I_Command
{
    private Entity Entity;
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
                SoundManager.Instance.PlayEffect("Build");
                Vector3 newObjectPosition = new Vector3(Case.worldPosition.x, Case.worldPosition.y + 1, Case.worldPosition.z);
                Entity.OnPlace(newObjectPosition);
                Entity.SetEntityPlaced(true);
                Entity.SetEntityAsObstacle();
                Case.entity = Entity;
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
