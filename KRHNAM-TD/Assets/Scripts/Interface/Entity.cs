using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    public Case Position
    {
        get
        {
            if (Grid.Instance == null)
            {
                ErrorManager.DebugLog("Grid reference is missing!");
                return null;
            }
            return Grid.Instance.CaseFromWorldPoint(transform.position);
        }
    }

    public virtual void OnPlace(Vector3 position)
    {
        transform.position = position;
    }
}
