using UnityEngine;

public class SmallAsteroid : Asteroid
{
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        this.gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    //void Update()
    //{

    //}

    public override void Init(Vector3 direction)
    {
        this.direction = direction.normalized;
        this.hp = 1;
        this.speed = 6;
        this.size = 1;
    }

}