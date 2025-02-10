using Abstract;
using UnityEngine;

public class AdvancedFireTower : Tower
{
    public GameObject projectilePrefab;

    public override void Attack(Collider co)
    {
        if (IsPlaced)
        {
            GameObject g = (GameObject)Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            g.GetComponent<MoveProjectile>().target = co.transform;
        }
    }
}
