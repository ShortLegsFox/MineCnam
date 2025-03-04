using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.AI;

public abstract class EnemyTypeAbs : MonoBehaviour
{
    public GameObject castle;
    protected float speed;
    public NavMeshAgent agent;

    public void Start()
    {
        castle = GameManager.Instance.Castle;
        agent = GetComponent<NavMeshAgent>();
        agent.speed = this.GetComponent<Enemy>().enemyData.MoveSpeed;
    }

    public virtual void Update()
    {

    }
}
