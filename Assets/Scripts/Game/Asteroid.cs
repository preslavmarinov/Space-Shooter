using UnityEngine;

public abstract class Asteroid : MonoBehaviour
{
    protected int hp;
    protected float speed;
    protected Vector3 direction;
    protected int size;
    protected Vector2 screenBounds;

    public GameManager gameManager;

    void Update()
    {
        transform.position += this.direction * this.speed * Time.deltaTime;

        if (this.IsOutOfBounds())
        {
            Destroy(gameObject);
        }
    }

    public abstract void Init(Vector3 direction);

    private bool IsOutOfBounds()
    {
        return transform.position.x > this.screenBounds.x + 1f || transform.position.x < -this.screenBounds.x - 1f ||
               transform.position.y > this.screenBounds.y + 1f || transform.position.y < -this.screenBounds.y - 1f;
    }

    public void TakeDamage()
    {
        this.hp--;

        if (this.hp == 0)
        {
            Destroy(gameObject);
            this.gameManager.AddScore(1);
            SoundEffectManager.Instance.PlayAsteroidDestroySound();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("LightBeam"))
        {
            Destroy(collision.gameObject);
            this.TakeDamage();
        }
        else if (collision.gameObject.CompareTag("Asteroid"))
        {
            SoundEffectManager.Instance.PlayAsteroidDestroySound();

            Asteroid collidedAsteroid = collision.GetComponent<Asteroid>();
            if (collidedAsteroid != null)
            {
                if (this.size == collidedAsteroid.size)
                {
                    Destroy(this.gameObject);
                    Destroy(collision.gameObject);
                }
                else
                {
                    if (this.size > collidedAsteroid.size)
                    {
                        Destroy(collidedAsteroid.gameObject);
                    }
                    else
                    {
                        Destroy(gameObject);
                    }
                }
            }
        }
    }
}
