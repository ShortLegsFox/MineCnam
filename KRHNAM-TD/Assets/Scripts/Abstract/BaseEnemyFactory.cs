using System;
using UnityEngine;
using Object = UnityEngine.Object;
using Interface;

public abstract class BaseEnemyFactory : I_EnemyFactory
{
    protected readonly GameManager GameManager;
    protected readonly Grid Grid;

    protected BaseEnemyFactory(GameManager gameManager, Grid grid)
    {
        GameManager = gameManager;
        Grid = grid;
    }

    public abstract Enemy CreateEnemy(EnemyType type, Transform spawnPoint);

    protected Enemy CreateEnemyInternal(Element element, EnemyType type, Transform spawnPoint)
    {
        if (!spawnPoint)
            throw new ArgumentNullException(nameof(spawnPoint));

        var enemyData = GameManager.GetEnemyData(element, type);
        if (!enemyData?.Prefab)
            throw new InvalidOperationException("Invalid enemy data or prefab");

        GameObject instance = Object.Instantiate(enemyData.Prefab, spawnPoint.position, Quaternion.Euler(0, 90, 0));

        instance.transform.SetParent(Grid.transform);

        var enemy = instance.GetComponent<Enemy>();

        return enemy;
    }
}
