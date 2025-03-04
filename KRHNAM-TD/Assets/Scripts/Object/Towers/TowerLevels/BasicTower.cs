using Abstract;
using UnityEngine;

public class BasicTower : Tower
{
    public override void Attack(Collider co)
    {
        if (isPlaced)
        {
            TowerData.TowerElement.Shoot(TowerData.projectilePrefab, this, co.transform);
        }
    }
}
