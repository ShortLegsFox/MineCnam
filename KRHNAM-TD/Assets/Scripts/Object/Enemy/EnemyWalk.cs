using UnityEngine;
using UnityEngine.AI;

public class EnemyWalk : EnemyTypeAbs
{
    new public void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        if (castle != null)
        {
            agent.SetDestination(castle.transform.position);
        }
    }
}