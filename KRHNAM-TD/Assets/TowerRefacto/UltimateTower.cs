using Abstract;
using UnityEngine;

public class UltimateTower : Tower
{
    public override void Attack(Collider co)
    {
        if (isPlaced)
        {
            TowerData.TowerElement.Shoot(TowerData.projectilePrefab, transform, co.transform);
        }
    }
}
