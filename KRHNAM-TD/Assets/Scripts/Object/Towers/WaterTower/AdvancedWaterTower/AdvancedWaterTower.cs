using Abstract;
using UnityEngine;

public class AdvancedWaterTower : Tower
{
    public override void Attack()
    {
        if (isPlaced)
        {
            Debug.Log("ATTACK ADVANCED WATER");
        }
    }
}
