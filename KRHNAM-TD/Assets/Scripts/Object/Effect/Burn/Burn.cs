using UnityEditor;
using UnityEngine;

public class Burn : Effect
{
    private float burnTick = 1f;
    private float nextBurnTick;
    private Element element;
    
    public Burn(float duration, EffectData effectData) : base(duration, effectData)
    {
        this.duration = duration;
        this.effectData = effectData;
        this.nextBurnTick = 0f;
        this.element = Element.Fire;
    }

    public override bool Apply(Enemy enemy)
    {
        elapsedTime += Time.deltaTime;
        
        if (elapsedTime >= duration)
        {
            enemy.debuffIcon.enabled = false;
            return false;
        }

        if (elapsedTime >= nextBurnTick)
        {
            enemy.TakeDamage(Element.Fire, 10.0f);
            nextBurnTick += burnTick;
        }
        
        enemy.debuffIcon.sprite = this.effectData.effectIcon;
        enemy.debuffIcon.enabled = true;

        return true;
    }
    
    public override Element GetElement()
    {
        return element;
    }

    public override void Refresh()
    {
        elapsedTime = 0;
        nextBurnTick = burnTick;
    }
}
