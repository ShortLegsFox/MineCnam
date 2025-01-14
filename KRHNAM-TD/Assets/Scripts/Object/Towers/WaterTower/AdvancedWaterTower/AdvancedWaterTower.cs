using Abstract;
using UnityEngine;

public class AdvancedWaterTower : Tower
{
    public GameObject projectilePrefab;

    public override void Attack(Collider co)
    {
        if (isPlaced)
        {
            GameObject g = (GameObject)Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            g.GetComponent<MoveProjectile>().target = co.transform;
        }
    }
}
