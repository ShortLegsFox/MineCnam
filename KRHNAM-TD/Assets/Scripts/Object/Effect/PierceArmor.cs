using UnityEngine;

public class PierceArmor : Effect
{
    public PierceArmor(float duration, EffectData effectData) : base(duration, effectData)
    {
        this.duration = duration;
    }
    
    public override bool Apply(Enemy enemy)
    {
        return true;
    }
} 
