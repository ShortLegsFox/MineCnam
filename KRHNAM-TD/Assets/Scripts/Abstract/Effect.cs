using UnityEngine;

public abstract class Effect
{
    public float duration;
    public float elapsedTime = 0f;

    public Effect(float _duration)
    {
        duration = _duration;
    }

    public virtual bool Apply(Enemy enemy)
    {
        return true;
    }
}
