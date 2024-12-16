using UnityEngine;

public class Rocket : MonoBehaviour
{
    private Vector2 screenBounds;
    private Vector2 rocketSize;

    public float leadDistance = 0.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Camera camera = Camera.main;
        screenBounds = camera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, camera.transform.position.z));

        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null )
        {
            rocketSize = spriteRenderer.bounds.extents;
        }
        else
        {
            rocketSize = Vector2.zero;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;

        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        mousePosition.z = 0;

        float clampedX = Mathf.Clamp(mousePosition.x, -screenBounds.x + rocketSize.x, screenBounds.x - rocketSize.x);
        float clampedY = Mathf.Clamp(mousePosition.y, -screenBounds.y + rocketSize.y, screenBounds.y - rocketSize.y);


        Vector2 direction = mousePosition - transform.position;

        float angle = (Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg) * -1;
        transform.rotation = Quaternion.Euler(0, 0, angle);


        transform.position = Vector2.Lerp(transform.position, new Vector2(clampedX, clampedY), 0.1f);
    }
}
