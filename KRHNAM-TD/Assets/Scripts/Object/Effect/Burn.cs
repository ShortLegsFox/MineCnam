using UnityEditor;
using UnityEngine;

public class Burn : Effect
{
    private float burnTick = 1f;
    private float nextBurnTick;
    private Element element;
    
    public Burn(float duration) : base(duration)
    {
        this.duration = duration;
        this.nextBurnTick = 0f;
        this.element = Element.Fire;
    }

    public override bool Apply(Enemy enemy)
    {
        elapsedTime += Time.deltaTime;
        
        if (elapsedTime >= duration)
        {
            return false;
        }

        if (elapsedTime >= nextBurnTick)
        {
            enemy.TakeDamage(Element.Fire, 10.0f, true);
            nextBurnTick += burnTick;
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
        nextBurnTick = burnTick;
    }
}
