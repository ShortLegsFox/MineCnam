using UnityEngine;

public class Burn : Effect
{
    public Burn(float duration) : base(duration)
    {
        this.duration = duration;
    }

    public override bool Apply(Enemy enemy)
    {
        return true;
    }
}
