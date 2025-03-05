using UnityEngine;

public class FireEnemyFactory : BaseEnemyFactory
{
    public FireEnemyFactory(GameManager gameManager, Grid grid) : base(gameManager, grid) { }
    
    public override Enemy CreateEnemy(EnemyType type, Transform spawnPoint)
    {
        return CreateEnemyInternal(Element.Fire, type, spawnPoint);
    }
}