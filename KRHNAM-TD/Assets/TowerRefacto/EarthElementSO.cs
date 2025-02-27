using Abstract;
using UnityEngine;

[CreateAssetMenu(fileName = "EarthElementSO", menuName = "Scriptable Objects/TowerElements/EarthElementSO")]
public class EarthElementSO : ElementSO
{
    public override void Shoot(GameObject projectilePrefab, Transform origin, Transform target)
    {
        GameObject g = Instantiate(projectilePrefab, origin.position, Quaternion.identity);
        g.GetComponent<MoveProjectile>().target = target;
        g.GetComponent<MoveProjectile>().SetTower(origin.GetComponent<Tower>());
    }
}
