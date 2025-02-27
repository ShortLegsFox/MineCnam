using Interface;
using UnityEngine;


[CreateAssetMenu(fileName = "ElementSO", menuName = "Scriptable Objects/ElementSO")]
public abstract class ElementSO : ScriptableObject, I_TowerElement
{
    public abstract void Shoot(GameObject projectilePrefab, Transform origin, Transform target);
}
