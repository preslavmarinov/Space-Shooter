using UnityEngine;

public class LightBeam : MonoBehaviour
{
    private Vector2 screenBounds;
    private Vector3 direction;

    public int speed = 10;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
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
        return transform.position.x > screenBounds.x || transform.position.x < -screenBounds.x ||
            transform.position.y > screenBounds.y || transform.position.y < -screenBounds.y;
    }
}
