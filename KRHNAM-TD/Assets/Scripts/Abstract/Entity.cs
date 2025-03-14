using UnityEngine;
using UnityEngine.AI;


public abstract class Entity : MonoBehaviour
{
    public bool isPlaced { get; set; } = false;

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

    public void Awake()
    {
        DisableEntityAsObstacle();
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


    public void DisableEntityAsObstacle()
    {
        if (this.GetComponent<NavMeshObstacle>() != null)
        {
            this.GetComponent<NavMeshObstacle>().enabled = false;
        }
    }
}
