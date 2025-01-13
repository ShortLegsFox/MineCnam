using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Scriptable Objects/EnemyData")]
public class EnemyData : ScriptableObject
{
    public Element Element;
    public GameObject Prefab;
    public int MaxHp;
    public int Damage;
    public int MoveSpeed;
}
