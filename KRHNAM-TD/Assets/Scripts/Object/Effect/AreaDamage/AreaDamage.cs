using System.Collections.Generic;
using UnityEngine;

public class AreaDamage : Effect
{
    private Element element;
    private Enemy thisEnemy = null;
    
    public AreaDamage(float duration, EffectData effectData) : base(duration, effectData)
    {
        this.duration = duration;
        this.effectData = effectData;
        this.element = Element.Earth;
    }

    public override bool Apply(Enemy enemy)
    {
        elapsedTime += Time.deltaTime;

        if (enemy == null)
        {
            DamageArea(enemy);
        }
        
        thisEnemy = enemy;
        
        if (elapsedTime >= duration)
        {
            enemy.debuffIcon.enabled = false;
            thisEnemy = null;
            return false;
        }
        
        return true;
    }
    
    public override Element GetElement()
    {
        return element;
    }

    public override void Refresh()
    {
        elapsedTime = 0;
        DamageArea(thisEnemy);
    }

    private void DamageArea(Enemy enemy)
    {
        List<Enemy> enemies = enemy.FindEnemiesInTheArea();
        foreach (Enemy e in enemies)
        {
            e.TakeDamage(Element.Earth, 5.0f);
        }
    }
}
