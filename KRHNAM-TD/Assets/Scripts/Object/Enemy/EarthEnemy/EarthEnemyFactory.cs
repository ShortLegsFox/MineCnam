using UnityEngine;

public class EarthEnemyFactory : BaseEnemyFactory
{
    public EarthEnemyFactory(GameManager gameManager, Grid grid) : base(gameManager, grid) { }
    
    public override Enemy CreateEnemy(EnemyType type, Transform spawnPoint)
    {
        return CreateEnemyInternal(Element.Earth, type, spawnPoint);
    }
}