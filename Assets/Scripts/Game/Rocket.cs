using UnityEngine;

public class Rocket : MonoBehaviour
{
    private Vector2 screenBounds;

    private Vector2 rocketSize;

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

        float clampedX = Mathf.Clamp(mousePosition.x, -screenBounds.x + rocketSize.x, screenBounds.x - rocketSize.x);
        float clampedY = Mathf.Clamp(mousePosition.y, -screenBounds.y + rocketSize.y, screenBounds.y - rocketSize.y);

        transform.position = Vector3.Lerp(transform.position, new Vector3(clampedX, clampedY, transform.position.z), 0.1f);

        Vector2 direction = mousePosition - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);



        //transform.position = new Vector3(mousePosition.x, mousePosition.y, transform.position.z);
        //transform.position = Vector3.Lerp(transform.position, new Vector3(clampedX, clampedY, transform.position.z), 0.1f);  -- smoooth
    }
}
