using UnityEngine;
using UnityEngine.AI;

public class EnemyFly : EnemyTypeAbs
{
    new public void Start()
    {
        base.Start();
    }

    // REmove with FLy behaviour
    public override void Update()
    {
        transform.position = new Vector3(transform.position.x, 10, transform.position.z);

        //transform.position.y = 0;
        if (castle != null)
        {
            agent.SetDestination(castle.transform.position);
        }
    }
}
