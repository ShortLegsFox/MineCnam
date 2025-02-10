using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Slider slidersss;
    private float currentHealth;
    public float maxHealth = 100;
    public Gradient gradient;
    public Image fill;


    public void Awake()
    {
        slidersss = GetComponent<Slider>();
    }

    public void SetMaxHealth(float health)
    {
        if (slidersss != null)
        {
            maxHealth = health;
            currentHealth = maxHealth;
            slidersss.maxValue = health;
            slidersss.value = health;
            fill.color = gradient.Evaluate(1f);
        }
        else
        {
            throw new System.Exception("Slider is null");
        }
    }

    public void SetHealth(float health)
    {
        slidersss.value = health;
        fill.color = gradient.Evaluate(slidersss.normalizedValue);
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        SetHealth(currentHealth);
    }
}
