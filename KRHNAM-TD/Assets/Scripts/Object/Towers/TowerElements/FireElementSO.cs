using Abstract;
using UnityEngine;

[CreateAssetMenu(fileName = "FireElementSO", menuName = "Scriptable Objects/TowerElements/FireElementSO")]
public class FireElementSO : ElementSO
{
    public override void Shoot(GameObject projectilePrefab, Transform origin, Transform target)
    {
        GameObject g = Object.Instantiate(projectilePrefab, origin.position, Quaternion.identity);
        g.GetComponent<MoveProjectile>().target = target;
        g.GetComponent<MoveProjectile>().SetTower(origin.GetComponent<Tower>());
    }
}
