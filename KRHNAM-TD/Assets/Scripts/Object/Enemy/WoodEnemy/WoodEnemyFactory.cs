using UnityEngine;

public class WoodEnemyFactory : BaseEnemyFactory
{
    public WoodEnemyFactory(GameManager gameManager, Grid grid) : base(gameManager, grid) { }
    
    public override Enemy CreateEnemy(EnemyType type, Transform spawnPoint)
    {
        return CreateEnemyInternal(Element.Wood, type, spawnPoint);
    }
}