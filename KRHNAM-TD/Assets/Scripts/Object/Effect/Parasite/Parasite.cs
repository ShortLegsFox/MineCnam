using UnityEngine;
using UnityEngine.AI;

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
        
        EnemyTypeAbs enemyMovement = enemy.GetComponent<EnemyTypeAbs>();
        
        if (parasitizedTarget == null && counter >= 4)
        {
            enemy.isParasitized = true;
            parasitizedTarget = enemy.FindNearestEnemy();
            if (parasitizedTarget != null)
            {
                enemy.target = parasitizedTarget.gameObject;
                enemyMovement.castle = parasitizedTarget.gameObject;
                enemyMovement.agent.SetDestination(enemy.target.transform.position);
                enemy.debuffIcon.sprite = this.effectData.effectIcon;
                enemy.debuffIcon.enabled = true;
            }
        }

        return true;
    }
    
    public void RemoveEffect(Enemy enemy)
    {
        EnemyTypeAbs enemyMovement = enemy.GetComponent<EnemyTypeAbs>();
        enemy.isParasitized = false;
        
        enemy.target = GameManager.Instance.Castle;
        enemyMovement.castle = GameManager.Instance.Castle;
        enemyMovement.agent.SetDestination(enemy.target.transform.position);

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
