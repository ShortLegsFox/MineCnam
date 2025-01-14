using UnityEngine;
using UnityEngine.AI;

public abstract class Entity : MonoBehaviour
{
    public bool isPlaced = false;

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

    private void Awake()
    {
        isPlaced = false;
    }

    private void Update()
    {
        if (isPlaced)
            SetEntityAsObstacle();
        else
            SetEntityAsNotObstacle();
    }

    public virtual void OnPlace(Vector3 position)
    {
        transform.position = position;
    }
    public static T InstantiateEntity<T>(GameObject prefab, Vector3 position, Quaternion rotation) where T : Entity
    {
        GameObject instance = Instantiate(prefab, position, rotation);
        return instance.GetComponent<T>();
    }

    private void SetEntityAsObstacle()
    {
        if (this.GetComponent<NavMeshObstacle>() != null)
        {
            this.GetComponent<NavMeshObstacle>().enabled = true;
        }
    }

    private void SetEntityAsNotObstacle()
    {
        if (this.GetComponent<NavMeshObstacle>() != null)
        {
            this.GetComponent<NavMeshObstacle>().enabled = false;
        }
    }

}
