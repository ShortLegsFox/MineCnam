using System;
using UnityEngine;

public class PierceArmor : Effect
{
    public PierceArmor(float duration, EffectData effectData) : base(duration, effectData)
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

        enemy.Armor = Mathf.RoundToInt(enemy.enemyData.Armor * 0.5f);
        enemy.debuffIcon.sprite = this.effectData.effectIcon;
        enemy.debuffIcon.enabled = true;
        
        return true;
    }
    
    public void RemoveEffect(Enemy enemy)
    {
        enemy.debuffIcon.enabled = false;
    }
} 
