using UnityEngine;

public abstract class Enemy : Entity
{
    public EnemyData enemyData;
    public Element element;
    private HealthBar healthBar;
    public float Hp { get; set; }

    private float lastAttackTime; // Stocke le temps de la dernière attaque

    public void Start()
    {
        healthBar = transform.Find("HealthbarCanva").Find("Healthbar").GetComponent<HealthBar>();
        healthBar.SetMaxHealth(enemyData.MaxHp);
        Hp = enemyData.MaxHp;
        lastAttackTime = -999f; // Initialise pour être sûr qu'il attaque dès qu'il atteint la cible
    }

    public void Update()
    {
        // Vérifie si l'ennemi est proche du château
        GameObject castle = GameManager.Instance.castle;
        if (castle != null)
        {
            Vector3 castlePosition = castle.transform.position;
            float distanceFromCastle = Vector3.Distance(transform.position, castlePosition);

            if (distanceFromCastle < 5)
            {
                // Attaque toutes les 2 secondes
                if (Time.time - lastAttackTime >= 2f)
                {
                    lastAttackTime = Time.time; // Met à jour le temps de la dernière attaque
                    castle.GetComponent<Castle>().TakeDamage(enemyData.Damage);
                }
            }
        }
    }

    public bool TakeDamage(Element AttackElement, float AttackDamage)
    {
        Debug.Log("TakeDamage");
        // Si la tour est forte contre l'ennemi
        if (AttackElement == GetElementInfos.GetWeakness(element))
        {
            AttackDamage = GetElementInfos.AddStrongDamage(AttackDamage);
        }

        // Si la tour est faible contre l'ennemi
        if (AttackElement == GetElementInfos.GetStrength(element))
        {
            AttackDamage = GetElementInfos.RemoveWeakDamage(AttackDamage);
        }

        this.Hp -= AttackDamage;
        healthBar.TakeDamage(AttackDamage);

        if (Hp <= 0)
        {
            Destroy(this.gameObject);
            return true;
        }
        return false;
    }
}
