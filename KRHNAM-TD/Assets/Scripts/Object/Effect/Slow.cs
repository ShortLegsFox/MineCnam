using System;
using UnityEngine;
using UnityEngine.AI;

public class Slow : Effect
{
    public Slow(float duration) : base(duration)
    {
        this.duration = duration;
    }
    
    public override bool Apply(Enemy enemy)
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= duration)
        {
            RemoveEffect(enemy);
            return false;
        }
        
        NavMeshAgent agent = enemy.GetComponent<NavMeshAgent>();

        agent.speed = (enemy.enemyData.MoveSpeed * 0.5f);

        return true;
    }

    public void RemoveEffect(Enemy enemy)
    {
        NavMeshAgent agent = enemy.GetComponent<NavMeshAgent>();
        agent.speed = enemy.enemyData.MoveSpeed;
    }
}
