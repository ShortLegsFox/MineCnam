using UnityEngine;

public class Castle : Entity
{
    public float maxHealth = 500;
    private float health;

    void Start()
    {
        health = maxHealth;
        HudManager.Instance.hpText.text = health.ToString();
    }

    public void TakeDamage(float damage)
    {
        Debug.Log("Castle take damage");
        RemoveHeartPoint(damage);
        Die();
    }

    private void RemoveHeartPoint(float damage)
    {
        if (health - damage < 0)
        {
            health = 0;
        }
        else
            health -= damage;

        HudManager.Instance.hpText.text = health.ToString();
    }

    private void Die()
    {
        if (health <= 0)
        {
            health = 0;
            Destroy(gameObject);
        }
    }

}
