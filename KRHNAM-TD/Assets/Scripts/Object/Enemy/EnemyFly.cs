using UnityEngine;
using UnityEngine.AI;

public class EnemyBulk : MonoBehaviour
{
    private GameObject castle;
    public float speed;
    private NavMeshAgent agent;

    void Start()
    {
        castle = GameObject.Find("Castle");
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
    }

    void Update()
    {
        if (castle != null)
        {
            agent.SetDestination(castle.transform.position);
        }
    }
}
