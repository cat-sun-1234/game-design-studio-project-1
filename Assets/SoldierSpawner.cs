using UnityEngine;

public class SoldierSpawner : MonoBehaviour
{

    public GameObject prefabToSpawn;

    [SerializeField]
    private BoxCollider2D randomSpawnerBoundaries;

    [SerializeField]
    private GameManager gameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();

        randomSpawnerBoundaries = GetComponent<BoxCollider2D>();
        SpawnSoldiers();
    }

    public void SpawnSoldiers()
    {
        // Get collider bounds
        Bounds bounds = randomSpawnerBoundaries.bounds;

        // Calculate random position within bounds
        for (int i = 0; i < gameManager.soldiersOnField; i++)
        {
            Vector2 randomPosition = new Vector2(
                Random.Range(bounds.min.x, bounds.max.x),
                Random.Range(bounds.min.y, bounds.max.y));

            Instantiate(prefabToSpawn, randomPosition, Quaternion.identity);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
