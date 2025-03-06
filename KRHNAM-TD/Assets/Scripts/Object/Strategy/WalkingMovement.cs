using Abstract;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "WalkingMovement", menuName = "Scriptable Objects/Enemy/MovementStrategy/WalkingMovement")]
public class WalkingMovement : MovementStrategy
{
    NavMeshAgent agent;
    Animator animator;
    Enemy enemy;

    public override void Initialize(Enemy enemy)
    {

        agent = enemy.GetComponent<NavMeshAgent>();
        agent.speed = enemy.enemyData.MoveSpeed;
        agent.baseOffset = 0.5f;
        animator = enemy.GetComponent<Animator>();
        this.enemy = enemy;

        if (agent == null) throw new System.Exception("NavMeshAgent not found in enemy object");
        if (animator == null) throw new System.Exception("Animator not found in enemy object");
    }

    public override void Move()
    {
        if (enemy.Target != null)
        {
            agent.SetDestination(enemy.Target.transform.position);
            bool isMoving = agent.velocity.magnitude > 0.5f;
            animator.SetBool("IsWalking", isMoving);
        }
    }
}
