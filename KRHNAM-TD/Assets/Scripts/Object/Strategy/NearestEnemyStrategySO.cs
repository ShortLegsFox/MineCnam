using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NearestEnemyStrategySO", menuName = "Scriptable Objects/Strategy/NearestEnemyStrategySO")]
public class NearestEnemyStrategySO : TargetingStrategySO
{
    public override Enemy SelectTarget(List<Enemy> enemies, Transform towerTransform)
    {
        if (enemies == null || enemies.Count == 0)
            return null;

        Enemy nearest = null;
        float minDist = float.MaxValue;

        foreach (Enemy enemy in enemies)
        {
            if (enemy == null) continue;

            float dist = Vector3.Distance(towerTransform.position, enemy.transform.position);
            if (dist < minDist)
            {
                minDist = dist;
                nearest = enemy;
            }
        }
        return nearest;
    }
}
