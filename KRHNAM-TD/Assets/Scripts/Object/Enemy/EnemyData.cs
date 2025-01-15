using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Scriptable Objects/EnemyData")]
public class EnemyData : ScriptableObject
{
    public GameObject Prefab;
    public int MaxHp;
    public int Damage;
    public int MoveSpeed;
    public Element element;
    public EnemyType type;
}
