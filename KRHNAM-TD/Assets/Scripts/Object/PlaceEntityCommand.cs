using UnityEngine;

public class PlaceEntityCommand : I_Command
{
    private Entity entityPrefab;  // L’entité à poser
    private Case Case;
    private Entity placedEntity;

    public PlaceEntityCommand(Entity entityPrefab, Case _case)
    {
        this.entityPrefab = entityPrefab;
        this.Case = _case;
    }

    public PlaceEntityCommand(Entity entityPrefab, Vector3 worldPosition)
    {
        this.entityPrefab = entityPrefab;
        this.Case = Grid.Instance.CaseFromWorldPoint(worldPosition);
    }

    public void Execute()
    {
        if (Case != null)
        {
            if (Case.IsEmpty)
            {
                Vector3 newObjectPosition = new Vector3(Case.worldPosition.x, Case.worldPosition.y + 1, Case.worldPosition.z);
                placedEntity = GameObject.Instantiate(entityPrefab, newObjectPosition, Quaternion.identity);
                Case.entity = placedEntity;
                EditorManager.Instance.selectedEntityPrefab = null;
                ErrorManager.DebugLog($"Entity {entityPrefab.name} placed at [{Case.GridX};{Case.GridY}");
            }
            else
                ErrorManager.DebugLog("Case is not empty.");
        }
        else
            ErrorManager.DebugLog("Invalid position for entity placement.");
    }

}
