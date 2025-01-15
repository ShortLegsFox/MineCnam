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
        if (castle != null)
        {
            agent.SetDestination(castle.transform.position);
        }
    }
}
