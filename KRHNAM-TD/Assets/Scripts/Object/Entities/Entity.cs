using UnityEngine;
using UnityEngine.AI;

public abstract class Entity : MonoBehaviour
{
    public bool IsPlaced { get; private set; } = false;

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
        position.y = 1;
        transform.position = position;
    }
    public static T InstantiateEntity<T>(GameObject prefab, Vector3 position, Quaternion rotation) where T : Entity
    {
        GameObject instance = Instantiate(prefab, position, rotation);
        return instance.GetComponent<T>();
    }

    public void SetEntityAsObstacle()
    {
        if (this.GetComponent<NavMeshObstacle>() != null)
        {
            this.GetComponent<NavMeshObstacle>().enabled = true;
        }
    }

    public void SetEntityPlaced(bool isPlaced)
    {
        this.IsPlaced = isPlaced;
    }


}
