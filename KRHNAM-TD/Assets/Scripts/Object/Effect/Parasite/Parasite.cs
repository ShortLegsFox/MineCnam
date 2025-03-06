using UnityEngine;

public class Parasite : Effect
{
    private Enemy parasitizedTarget;
    private int counter;

    public Parasite(float duration, EffectData effectData) : base(duration, effectData)
    {
        this.duration = duration;
        this.effectData = effectData;
        this.counter = 0;
    }

    public override bool Apply(Enemy enemy)
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= duration)
        {
            RemoveEffect(enemy);
            return false;
        }

        if (parasitizedTarget == null && counter >= 4)
        {
            enemy.isParasitized = true;
            parasitizedTarget = enemy.FindNearestEnemy();
            if (parasitizedTarget != null)
            {
                enemy.target = parasitizedTarget.gameObject;
                enemy.debuffIcon.sprite = this.effectData.effectIcon;
                enemy.debuffIcon.enabled = true;
            }
        }

        return true;
    }

    public void RemoveEffect(Enemy enemy)
    {
        enemy.isParasitized = false;
        enemy.target = GameManager.Instance.Castle;

        // Réinitialiser l'état du parasite
        parasitizedTarget = null;
        enemy.debuffIcon.enabled = false;
    }

    public override void Refresh()
    {
        elapsedTime = 0;
        counter++;
    }
}
