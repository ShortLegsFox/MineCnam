using UnityEngine;

public class Slow : I_Effect
{
    public void Apply(Enemy enemy)
    {
        enemy.enemyData.MoveSpeed = (enemy.enemyData.MoveSpeed / 2);
    }
}
