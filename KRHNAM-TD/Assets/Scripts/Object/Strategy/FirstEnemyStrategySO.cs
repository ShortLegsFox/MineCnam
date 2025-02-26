using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "FirstEnemyStrategySO", menuName = "Scriptable Objects/Strategy/FirstEnemyStrategySO")]
public class FirstEnemyStrategySO : TargetingStrategySO
{
    public override Enemy SelectTarget(List<Enemy> enemies, Transform towerTransform)
    {
        if (enemies == null || enemies.Count == 0)
            return null;

        return enemies.First();
    }
}
