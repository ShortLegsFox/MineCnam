using Abstract;
using UnityEngine;

public class BasicWaterTower : Tower
{
    public override void Attack()
    {
        if (isPlaced)
        {
            Debug.Log("ATTACK BASIC WATER");
        }
    }
}
