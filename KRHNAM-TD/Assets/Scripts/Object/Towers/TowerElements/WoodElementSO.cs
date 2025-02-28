using Abstract;
using UnityEngine;

[CreateAssetMenu(fileName = "WoodElementSO", menuName = "Scriptable Objects/TowerElements/WoodElementSO")]
public class WoodElementSO : ElementSO
{
    public override void Shoot(GameObject projectilePrefab, Transform origin, Transform target)
    {
        GameObject g = Object.Instantiate(projectilePrefab, origin.position, Quaternion.identity);
        g.GetComponent<MoveProjectile>().target = target;
        g.GetComponent<MoveProjectile>().SetTower(origin.GetComponent<Tower>());
    }
}
