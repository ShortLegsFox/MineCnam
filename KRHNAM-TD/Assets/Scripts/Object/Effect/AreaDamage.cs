using UnityEngine;

public class AreaDamage : Effect
{
    public AreaDamage(float duration, EffectData effectData) : base(duration, effectData)
    {
        this.duration = duration;
    }
    
    public override bool Apply(Enemy enemy)
    {
        return true;
    }
}
