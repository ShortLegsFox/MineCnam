public class EnemyBulk : EnemyTypeAbs
{
    new public void Start()
    {
        base.Start();
    }

    // REmove with Bulk behaviour
    public override void Update()
    {
        if (castle != null)
        {
            agent.SetDestination(castle.transform.position);
        }
    }
}
