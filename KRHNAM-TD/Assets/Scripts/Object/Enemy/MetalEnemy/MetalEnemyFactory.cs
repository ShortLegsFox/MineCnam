using UnityEngine;

public class MetalEnemyFactory : BaseEnemyFactory
{
    public MetalEnemyFactory(GameManager gameManager, Grid grid) : base(gameManager, grid) { }
    
    public override Enemy CreateEnemy(EnemyType type, Transform spawnPoint)
    {
        return CreateEnemyInternal(Element.Metal, type, spawnPoint);
    }
}