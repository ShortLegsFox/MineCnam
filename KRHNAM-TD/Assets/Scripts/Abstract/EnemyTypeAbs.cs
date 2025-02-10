using UnityEngine;
using UnityEngine.AI;

public abstract class EnemyTypeAbs : MonoBehaviour
{
    protected GameObject castle;
    protected float speed;
    protected NavMeshAgent agent ;

    public void Start()
    {
        castle = GameObject.Find("Castle");
        agent = GetComponent<NavMeshAgent>();
        agent.speed = this.GetComponent<Enemy>().enemyData.MoveSpeed;
    }

    public virtual void Update()
    {
        
    }
}
