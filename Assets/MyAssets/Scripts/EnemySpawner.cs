using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float heightOffset = 4f;
    Vector2 screenDimensions = new Vector2(Screen.width, Screen.height);
    Vector2 worldBottomLeft;
    Vector2 worldTopRight;

    [SerializeField] GameObject enemy;
    [SerializeField] int enemyCount = 10;

    float counter;
    [SerializeField] float spawnDelay = 2f;

    void Awake()
    {
        //bereken de hoogte van het scherm in worldspace
        worldTopRight = Camera.main.ScreenToWorldPoint(new Vector2(screenDimensions.x, screenDimensions.y));
        worldBottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));

        //bereken een nieuwe positie die ons altijd in het midden plaatst maar x units boven ons scherm.
        Vector2 newPosition = new Vector2(Camera.main.transform.position.x, worldTopRight.y + heightOffset);
        transform.position = newPosition;
    }

    void Start()
    {

    }

    void Update()
    {
        counter += Time.deltaTime;
        if (counter >= spawnDelay)
        {
            Spawner();
            counter = 0f;
        }
    }

    void Spawner()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            GameObject clone = Instantiate(enemy, transform.position, Quaternion.identity);
            float randomX = Random.Range(worldBottomLeft.x, worldTopRight.x);
            Vector2 newPosition = new Vector2(randomX, transform.position.y);
            clone.transform.position = newPosition;
        }

    }
}
