using UnityEngine;

public class Castle : MonoBehaviour
{
    public float Hp;
    private float MaxHp;
    private HealthBar healthBar;

    void Start()
    {
        healthBar = HudManager.Instance.CastleHealthbar;
        MaxHp = Hp;
        healthBar.SetMaxHealth(MaxHp);
    }


    public void TakeDamage(float damage)
    {
        //Debug.Log("Castle take damage");
        RemoveHeartPoint(damage);
        healthBar.TakeDamage(damage);

    }

    private void RemoveHeartPoint(float damage)
    {
        if (Hp - damage < 0)
        {
            Hp = 0;
            Die();
        }
        else
            Hp -= damage;

    }

    private void Die()
    {
        Destroy(gameObject);
        GameManager.Instance.GameOver();
    }
}
