using UnityEngine;

public class Rocket : MonoBehaviour
{
    private Vector2 screenBounds;
    private Vector2 rocketSize;
    private float beamSpawnOffset = 0.3f;

    public GameObject lightBeam;
    public Transform firePoint;
    public GameManager gameManager;

    void Start()
    {
        this.screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null )
        {
            this.rocketSize = spriteRenderer.bounds.extents;
        }
        else
        {
            this.rocketSize = Vector2.zero;
        }
    }

    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;

        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        mousePosition.z = 0;

        float clampedX = Mathf.Clamp(mousePosition.x, -this.screenBounds.x + rocketSize.x, this.screenBounds.x - rocketSize.x);
        float clampedY = Mathf.Clamp(mousePosition.y, -this.screenBounds.y + rocketSize.y, this.screenBounds.y - rocketSize.y);


        Vector2 direction = mousePosition - transform.position;

        float angle = (Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg) * -1;
        transform.rotation = Quaternion.Euler(0, 0, angle);


        transform.position = Vector2.Lerp(transform.position, new Vector2(clampedX, clampedY), 0.1f);

        if (Input.GetMouseButtonDown(0))
        {
            SoundEffectManager.Instance.PlayLaserSound();
            this.ShootLightBeam(angle);
        }
    }

    private void ShootLightBeam(float angle)
    {
        Vector3 spawnPosition = this.firePoint.position + (this.firePoint.up * this.beamSpawnOffset);
        GameObject lightBeam = Instantiate(this.lightBeam, spawnPosition, Quaternion.Euler(0, 0, angle - 90));

        LightBeam lightBeamScript = lightBeam.GetComponent<LightBeam>();
        if (lightBeamScript != null)
        {
            lightBeamScript.SetDirection(firePoint.up);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            SoundEffectManager.Instance.PlayRocketDestroySound();
            this.gameManager.GameOver();
            Destroy(gameObject);

            if (this.gameManager.playerScore > PlayerPrefs.GetInt("HighScore", 0))
            {
                PlayerPrefs.SetInt("HighScore", this.gameManager.playerScore);
                PlayerPrefs.Save();
            }
        } 
    }
}
