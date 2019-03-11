using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Statistics")]
    public float verticalSpeed;
    private SoundController soundController; //used to play a sound on collision with enemy and after shoting

    private void Start()
    {
        soundController = FindObjectOfType<SoundController>();
        soundController.playerShot.Play();
    }
    // Update is called once per frame
    void Update()
    {
        Move();   
    }

    //choose direction depends on position of respawn
    void Move()
    {
        if(transform.position.y>=0.4f)
        {
            transform.position += new Vector3(0, verticalSpeed * Time.deltaTime, 0);
        }
        else if (transform.position.y<=-0.4f)
        {
            transform.position += new Vector3(0, -verticalSpeed * Time.deltaTime, 0);
        }
        else if (transform.position.x >=0.4f)
        {
            transform.position += new Vector3(verticalSpeed * Time.deltaTime, 0, 0);
        }
        else if (transform.position.x <=-0.4f)
        {
            transform.position += new Vector3(-verticalSpeed * Time.deltaTime, 0, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            soundController.enemyHit.Play();
            Destroy(gameObject);
        }
        else if(collision.CompareTag("Limiter"))
        {
            Destroy(gameObject);
        }

    }
}
