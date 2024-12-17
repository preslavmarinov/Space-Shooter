using UnityEngine;

public abstract class Asteroid : MonoBehaviour
{
    protected int hp;
    protected float speed;
    protected Vector3 direction;
    protected int size;
    protected Vector2 screenBounds;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;

        if (this.IsOutOfBounds())
        {
            Destroy(gameObject);
        }
    }

    public abstract void Init(Vector3 direction);

    private bool IsOutOfBounds()
    {
        return transform.position.x > screenBounds.x + 1f || transform.position.x < -screenBounds.x - 1f ||
               transform.position.y > screenBounds.y + 1f || transform.position.y < -screenBounds.y - 1f;
    }

    public void TakeDamage()
    {
        hp--;

        if (hp == 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("LightBeam"))
        {
            this.TakeDamage();
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Asteroid"))
        {
            Debug.Log("AST COLLISON");

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
                        Destroy(this.gameObject);
                    }
                }
            }
        }
    }
}
