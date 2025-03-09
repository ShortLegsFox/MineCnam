using UnityEngine;

public class WaterEnemyFactory : BaseEnemyFactory
{
    public WaterEnemyFactory(GameManager gameManager, Grid grid) : base(gameManager, grid) { }
    
    public override Enemy CreateEnemy(EnemyType type, Transform spawnPoint)
    {
        return CreateEnemyInternal(Element.Water, type, spawnPoint);
    }
}