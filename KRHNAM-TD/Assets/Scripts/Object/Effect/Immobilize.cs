using UnityEngine;

public class Immobilize : Effect
{
    public Immobilize(float duration, EffectData effectData) : base(duration, effectData)
    {
        this.duration = duration;
    }

    public override bool Apply(Enemy enemy)
    {
        return true;
    }    
}
