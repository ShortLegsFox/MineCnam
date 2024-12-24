using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;

    [SerializeField] private float minimumSpawnTime;
    [SerializeField] private float maximumSpawnTime;
    [SerializeField] private float timeUntilSpawn;

    void Awake()
    {
        SetTimeUntilSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        timeUntilSpawn -= Time.deltaTime;
        if ( timeUntilSpawn <= 0)
        {
            Instantiate(enemyPrefab,transform.position , Quaternion.identity);
            SetTimeUntilSpawn();
        }
    }

    private void SetTimeUntilSpawn()
    {
        timeUntilSpawn = Random.Range(minimumSpawnTime, maximumSpawnTime);
    }
}
