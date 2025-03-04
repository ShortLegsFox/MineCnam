using Abstract;
using Interface;
using UnityEngine;

public class WaterElement : I_TowerElement
{
    public void Shoot(GameObject projectilePrefab, Tower tower, Transform target)
    {
        GameObject g = Object.Instantiate(projectilePrefab, tower.Shooter.position, Quaternion.identity);
        g.GetComponent<MoveProjectile>().target = target;
        g.GetComponent<MoveProjectile>().SetTower(tower);
    }
}
