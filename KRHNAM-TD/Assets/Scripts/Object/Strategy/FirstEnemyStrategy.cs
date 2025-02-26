using Interface;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FirstEnemyStrategy : I_TargetingStrategy
{
    public Enemy SelectTarget(List<Enemy> enemies, Transform towerTransform)
    {
        if (enemies == null || enemies.Count == 0)
            return null;

        return enemies.First();
    }
}
