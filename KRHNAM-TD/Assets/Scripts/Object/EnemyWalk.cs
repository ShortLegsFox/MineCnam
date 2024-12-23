using UnityEngine;

public class EnemyWalk : MonoBehaviour
{
    public GameObject castle;
    public float speed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = castle.transform.position - transform.position;

        transform.position = Vector2.MoveTowards(this.transform.position, castle.transform.position, speed * Time.deltaTime);
    }
}
