using Abstract;
using UnityEngine;

public class MoveProjectile : MonoBehaviour
{
    public float speed = 10;
    public Transform target;
    public Tower tower;


    // Update is called once per frame
    void FixedUpdate()
    {
        //go to target
        if (target)
        {
            Vector3 dir = target.position - transform.position;
            GetComponent<Rigidbody>().linearVelocity = dir.normalized * speed;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetTower(Tower towerToSet)
    {
        tower = towerToSet;
    }

    void OnTriggerEnter(Collider co)
    {
        Debug.Log("Trigger projectile on entity");
        if (co.GetComponent<Enemy>())
        {
            Debug.Log("Trigger projectile on entity ENEMY");
            Destroy(gameObject);
            Enemy enemy = co.GetComponent<Enemy>();
            if (enemy != null)
            {
                bool killed = enemy.TakeDamage(tower.towerData.Element, tower.towerData.Damage);
                if (killed)
                    tower.OnEnemyDead(enemy);
            }
            else
                throw new System.Exception("Enemy is null");
        }
    }
}
