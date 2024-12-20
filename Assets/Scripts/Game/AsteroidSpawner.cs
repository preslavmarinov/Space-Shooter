using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    private float timer;
    private float gameTime;
    private float minSpawnRate = 0.4f;

    public GameObject[] asteroidPrefabs;
    public float spawnRate = 2f;
    public float spawnRateDecreaseInterval = 10f;
    public float spawnRateDecreaseAmount = 0.1f;

    void Update()
    {
        this.timer += Time.deltaTime;
        if (this.timer > this.spawnRate) 
        {
            this.SpawnAsteroid();
            this.timer = 0f;
        }

        this.gameTime += Time.deltaTime;
        if (this.gameTime > this.spawnRateDecreaseInterval)
        {
            this.DecreaseSpawnRate();
            this.gameTime = 0f;
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

    private void DecreaseSpawnRate()
    {
        this.spawnRate = Mathf.Max(this.minSpawnRate, this.spawnRate - this.spawnRateDecreaseAmount);
    }
}
