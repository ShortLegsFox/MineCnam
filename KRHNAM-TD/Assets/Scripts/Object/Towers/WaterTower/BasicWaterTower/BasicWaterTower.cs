using Abstract;
using UnityEngine;
using UnityEngine.AI;

public class BasicWaterTower : Tower
{
    public override void Attack()
    {
        if (isPlaced)
        {
            Debug.Log("ATTACK !!");
        }
    }
    
    private void Update()
    {
        Attack();
    }
}
