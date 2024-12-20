using UnityEngine;

public class LightBeam : MonoBehaviour
{
    private Vector2 screenBounds;
    private Vector3 direction;

    public int speed = 10;

    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    void Update()
    {
        transform.position += this.direction * this.speed * Time.deltaTime;

        if (this.IsOutOfBounds())
        {
            Destroy(gameObject);
        }
    }

    public void SetDirection(Vector3 newDirection)
    {
        this.direction = newDirection.normalized;
    }

    private bool IsOutOfBounds()
    {
        return transform.position.x > this.screenBounds.x || transform.position.x < -this.screenBounds.x ||
            transform.position.y > this.screenBounds.y || transform.position.y < -this.screenBounds.y;
    }
}
