using System.Collections.Generic;
using UnityEngine;

namespace Interface
{
    public interface I_TargetingStrategy
    {
        Enemy SelectTarget(List<Enemy> enemies, Transform towerTransform);
    }
}
