using UnityEngine;

public class BigAsteroid : Asteroid
{
    void Start()
    {
        this.screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        this.gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    public override void Init(Vector3 direction)
    {
        this.direction = direction.normalized;
        this.hp = 5;
        this.speed = 2;
        this.size = 3;
    }
}
