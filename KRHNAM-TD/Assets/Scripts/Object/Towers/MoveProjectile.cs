using UnityEngine;

public class MoveProjectile : MonoBehaviour
{
    public float speed = 10;
    public Transform target; 
    

    // Update is called once per frame
    void FixedUpdate()
    {
        //go to target
        if (target) {
            Vector3 dir = target.position - transform.position;
            GetComponent<Rigidbody> ().linearVelocity = dir.normalized * speed;
        }
        else
        {
            Destroy (gameObject);
        }
    }
    
    void OnTriggerEnter(Collider co) {
        Debug.Log("Trigger projectile on entity");
        if (co.GetComponent<EnemyWalk>()) {
            Debug.Log("Trigger projectile on entity ENEMY");
            Destroy(gameObject);
        }
    }
}
