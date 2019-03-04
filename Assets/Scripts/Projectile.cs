using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float verticalSpeed;
    public BoarSpawner spawner;

    private void Start()
    {
        spawner = FindObjectOfType<BoarSpawner>();
    }
    // Update is called once per frame
    void Update()
    {
        Move();   
    }

    void Move()
    {
        //jeżeli pozycja jest taka to leć tam
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
            Destroy(gameObject);
            Destroy(collision.gameObject);
            spawner.score += 1;
        }
        else if(collision.CompareTag("Limiter"))
        {
            Destroy(gameObject);
        }

    }
}
