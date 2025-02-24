using UnityEngine;

public class EnemyWalk : EnemyTypeAbs
{

    private Animator animator;
    new public void Start()
    {
        animator = GetComponent<Animator>();
        base.Start();
    }

    public override void Update()
    {
        if (castle != null)
        {
            agent.SetDestination(castle.transform.position);


            if (agent.velocity.magnitude > 0.5f)
            {
                animator.SetBool("IsWalking", true);
            }
            else
            {
                animator.SetBool("IsWalking", false);
            }
        }
    }
}