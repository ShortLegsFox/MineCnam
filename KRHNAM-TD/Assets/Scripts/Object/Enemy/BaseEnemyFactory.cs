using System;
using UnityEngine;
using Object = UnityEngine.Object;

public abstract class BaseEnemyFactory : I_EnemyFactory
{
    protected GameManager _gameManager;
    protected Grid _grid;

    protected BaseEnemyFactory(GameManager gameManager, Grid grid)
    {
        _gameManager = gameManager;
        _grid = grid;
    }

    public abstract Enemy CreateEnemy(EnemyType type);
    
    public abstract Enemy CreateEnemy(EnemyType type, Transform spawnPoint);

    protected Enemy CreateEnemyInternal(Element element, EnemyType type, Transform spawnPoint)
    {
        if (spawnPoint == null)
            throw new System.ArgumentNullException("spawnPoint");

        var enemyData = _gameManager.GetEnemyData(element, type);
        if (enemyData?.Prefab == null)
            throw new InvalidOperationException("Invalid enemy data or prefab");
        
        GameObject instance = Object.Instantiate(enemyData.Prefab, spawnPoint.position, Quaternion.Euler(0, 90, 0));
        
        instance.transform.SetParent(_grid.transform);

        var enemy = instance.GetComponent<Enemy>();

        return enemy;
    }
}
