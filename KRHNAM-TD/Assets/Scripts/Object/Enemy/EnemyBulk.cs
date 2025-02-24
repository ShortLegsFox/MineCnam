using UnityEngine;

public class EnemyBulk : EnemyTypeAbs

{

    private Animator animator;
    new public void Start()
    {
        animator = GetComponent<Animator>();
        base.Start();
    }

    // REmove with Bulk behaviour
    public override void Update()
    {
        if (castle != null)
        {
            agent.SetDestination(castle.transform.position);
            Debug.Log(agent.velocity.magnitude);

            if (agent.velocity.magnitude > 0.5f) // Si l'ennemi bouge
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
