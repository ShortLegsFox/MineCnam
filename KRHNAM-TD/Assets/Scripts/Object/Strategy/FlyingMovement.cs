using Abstract;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "FlyingMovement", menuName = "Scriptable Objects/Enemy/MovementStrategy/FlyingMovement")]
public class FlyingMovement : MovementStrategy
{
    NavMeshAgent agent;
    Animator animator;
    Enemy enemy;

    public override void Initialize(Enemy enemy)
    {

        agent = enemy.GetComponent<NavMeshAgent>();
        agent.speed = enemy.enemyData.MoveSpeed;
        //agent.baseOffset = 5f;
        animator = enemy.GetComponent<Animator>();
        this.enemy = enemy;

        if (agent == null) throw new System.Exception("NavMeshAgent not found in enemy object");
        if (animator == null) throw new System.Exception("Animator not found in enemy object");
    }

    public override void Move()
    {
        enemy.transform.position = new Vector3(enemy.transform.position.x, 5, enemy.transform.position.z);
        if (enemy.target != null)
        {
            agent.SetDestination(enemy.target.transform.position);
        }
    }
}
