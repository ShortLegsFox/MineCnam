using UnityEngine;

public class PierceArmor : Effect
{
    public PierceArmor(float duration) : base(duration)
    {
        this.duration = duration;
    }
    
    public override bool Apply(Enemy enemy)
    {
        return true;
    }
} 
