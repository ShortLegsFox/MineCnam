using Interface;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TargetingStrategySO", menuName = "Scriptable Objects/TargetingStrategySO")]
public abstract class TargetingStrategySO : ScriptableObject, I_TargetingStrategy
{
    public Sprite strategySprite;
    public abstract Enemy SelectTarget(List<Enemy> enemies, Transform towerTransform);
}
