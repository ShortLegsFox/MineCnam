using Abstract;
using UnityEngine;

[CreateAssetMenu(fileName = "WaterElementSO", menuName = "Scriptable Objects/TowerElements/WaterElementSO")]
public class WaterElementSO : ElementSO
{
    public override void Shoot(GameObject projectilePrefab, Transform origin, Transform target)
    {
        GameObject g = Object.Instantiate(projectilePrefab, origin.position, Quaternion.identity);
        g.GetComponent<MoveProjectile>().target = target;
        g.GetComponent<MoveProjectile>().SetTower(origin.GetComponent<Tower>());
    }
}
