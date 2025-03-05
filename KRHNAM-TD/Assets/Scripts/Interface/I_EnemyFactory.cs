using Abstract;
using UnityEngine;

public interface I_EnemyFactory
{
    public Enemy CreateEnemy(EnemyType type);
    public Enemy CreateEnemy(EnemyType type, Transform spawnPoint);
}