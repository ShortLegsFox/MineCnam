using UnityEngine;

[CreateAssetMenu(fileName = "TowerData", menuName = "Scriptable Objects/TowerData")]
public class TowerData : ScriptableObject
{
    public Element Element;
    public TowerLevel Level;
    public GameObject Prefab;
    public int MaxHp;
    public int Damage;
    public int Range;
    public float AttackSpeed;
    public TargetingStrategySO targetingStrategy;
    public GameObject projectilePrefab;
    public ElementSO TowerElement;
}
