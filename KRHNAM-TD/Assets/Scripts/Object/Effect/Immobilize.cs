using UnityEngine;

public class Immobilize : Effect
{
    public Immobilize(float duration) : base(duration)
    {
        this.duration = duration;
    }

    public override bool Apply(Enemy enemy)
    {
        return true;
    }    
}
