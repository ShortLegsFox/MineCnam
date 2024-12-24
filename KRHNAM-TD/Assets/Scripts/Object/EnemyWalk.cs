using UnityEngine;
using UnityEngine.AI;

public class EnemyWalk : MonoBehaviour
{
    private GameObject castle;
    public float speed;
    private NavMeshAgent agent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        castle = GameObject.Find("Castle");
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (castle != null)
        {
            agent.SetDestination(castle.transform.position);
        }
        //transform.position = Vector3.MoveTowards(transform.position, castle.transform.position, speed * Time.deltaTime);
    }
}
