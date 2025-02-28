using Abstract;
using Interface;
using UnityEngine;

public class WaterElement : I_TowerElement
{
    public void Shoot(GameObject projectilePrefab, Transform origin, Transform target)
    {
        GameObject g = Object.Instantiate(projectilePrefab, origin.position, Quaternion.identity);
        g.GetComponent<MoveProjectile>().target = target;
        g.GetComponent<MoveProjectile>().SetTower(origin.GetComponent<Tower>());
    }
}
