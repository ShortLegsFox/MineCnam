using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FirstEnemyStrategySO", menuName = "Scriptable Objects/Strategy/LowestHealthStrategySO")]
public class LowestHealthStrategySO : TargetingStrategySO
{
    public override Enemy SelectTarget(List<Enemy> enemies, Transform towerTransform)
    {
        if (enemies == null || enemies.Count == 0)
            return null;

        Enemy weakest = enemies[0];
        float minHealth = weakest.Hp;

        for (int i = 1; i < enemies.Count; i++)
        {
            Enemy e = enemies[i];
            if (e != null && e.Hp < minHealth)
            {
                weakest = e;
                minHealth = e.Hp;
            }
        }

        return weakest;
    }
}
