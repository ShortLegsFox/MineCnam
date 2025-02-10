using Abstract;
using UnityEngine;

public class UltimateIronTower : Tower
{
    public GameObject projectilePrefab;
    public override void Attack(Collider co)
    {
        if (isPlaced)
        {
            Vector3 position = transform.position;
            position.y += 5f;
            GameObject g = (GameObject)Instantiate(projectilePrefab, position, Quaternion.identity);
            g.GetComponent<MoveProjectile>().target = co.transform;
            g.GetComponent<MoveProjectile>().SetTower(this);
        }
    }
}
