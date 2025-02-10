using Abstract;
using UnityEngine;

public class AdvancedWaterTower : Tower
{
    public GameObject projectilePrefab;

    public override void Attack(Collider co)
    {
        if (IsPlaced)
        {
            Vector3 position = transform.position;
            position.y += 3f;
            GameObject g = (GameObject)Instantiate(projectilePrefab, position, Quaternion.identity);
            g.GetComponent<MoveProjectile>().target = co.transform;
            g.GetComponent<MoveProjectile>().SetTower(this);
        }
    }
}
