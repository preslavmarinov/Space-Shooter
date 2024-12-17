using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    private float timer;

    public GameObject[] asteroidPrefabs;
    public float spawnRate = 2f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > spawnRate) 
        {
            this.SpawnAsteroid();
            timer = 0f;
        }
    }

    private void SpawnAsteroid()
    {
        GameObject randPrefab = this.asteroidPrefabs[Random.Range(0, this.asteroidPrefabs.Length)];

        Vector2 spawnPosition = this.getRandomSpawnPosition();

        GameObject asteroid = Instantiate(randPrefab, spawnPosition, Quaternion.identity);

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePosition - (Vector3)spawnPosition;
        direction.z = 0;

        Asteroid asteroidScript = asteroid.GetComponent<Asteroid>();
        asteroidScript.Init(direction);
    }

    private Vector2 getRandomSpawnPosition()
    {
        if (Camera.main == null)
        {
            Debug.LogWarning("Main Camera not found!");
            return Vector2.zero;
        }

        float x, y;
        Vector2 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        if (Random.value > 0.5f)
        {
            // Spawn on the left or right
            x = Random.value > 0.5f ? screenBounds.x + 1f : -screenBounds.x - 1f;
            y = Random.Range(-screenBounds.y, screenBounds.y);
        }
        else
        {
            // Spawn on the top or bottom
            x = Random.Range(-screenBounds.x, screenBounds.x);
            y = Random.value > 0.5f ? screenBounds.y + 1f : -screenBounds.y - 1f;
        }

        return new Vector2(x, y);
    }
}
