using UnityEngine;

public abstract class Effect
{
    protected float duration;
    protected float elapsedTime = 0f;
    protected EffectData effectData;

    public Effect(float duration, EffectData effectData)
    {
        this.duration = duration;
        this.effectData = effectData;
    }

    public virtual bool Apply(Enemy enemy)
    {
        return true;
    }

    public virtual void Refresh() { }

    public virtual Element GetElement()
    {
        return Element.Earth; 
    }
}
