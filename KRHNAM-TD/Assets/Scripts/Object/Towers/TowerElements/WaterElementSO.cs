using Abstract;
using UnityEngine;

[CreateAssetMenu(fileName = "WaterElementSO", menuName = "Scriptable Objects/TowerElements/WaterElementSO")]
public class WaterElementSO : ElementSO
{
    public override void Shoot(GameObject projectilePrefab, Tower tower, Transform target)
    {
        GameObject g = Object.Instantiate(projectilePrefab, tower.Shooter.position, Quaternion.identity);
        g.GetComponent<MoveProjectile>().target = target;
        g.GetComponent<MoveProjectile>().SetTower(tower);
    }
}
