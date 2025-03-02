using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Slow : Effect
{
    private Element element; 
    private EffectData effectData;

    
    public Slow(float duration, EffectData effectData) : base(duration)
    {
        this.duration = duration;
        this.effectData = effectData;
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

        enemy.debuffIcon.sprite = this.effectData.effectIcon;
        enemy.debuffIcon.enabled = true;

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
        enemy.debuffIcon.enabled = false;
    }
}
