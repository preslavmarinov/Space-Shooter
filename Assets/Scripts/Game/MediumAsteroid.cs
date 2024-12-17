using UnityEngine;

public class MediumAsteroid : Asteroid
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    //void Update()
    //{

    //}

    public override void Init(Vector3 direction)
    {
        this.direction = direction.normalized;
        this.hp = 3;
        this.speed = 4;
        this.size = 2;
    }
}
