using UnityEngine;

public abstract class Enemy : I_Entity
{
    public int Hp {  get; set; }
    public int Type { get; set; }
    public int Element {  get; set; }
    public int MoveSpeed { get; set; }
}
