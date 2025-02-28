using System;
using UnityEngine;
using UnityEngine.AI;

public class Slow : Effect
{
    private Element element; 
    
    public Slow(float duration) : base(duration)
    {
        this.duration = duration;
        this.element = Element.Water;
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

    public override void Refresh()
    {
        elapsedTime = 0;
    }

    public override Element GetElement()
    {
        return element;
    }

    public void RemoveEffect(Enemy enemy)
    {
        NavMeshAgent agent = enemy.GetComponent<NavMeshAgent>();
        agent.speed = enemy.enemyData.MoveSpeed;
    }
}
