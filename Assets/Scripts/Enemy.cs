using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    //pozycja gracza
    public Transform target;
    //pozycja dzika
    private Transform boar;
    //prędkość dzika
    public float speed;
    private BoarSpawner spawner;

    // Start is called before the first frame update
    void Start()
    {
        spawner = FindObjectOfType<BoarSpawner>();
        //pobierz pozycję dzika
        boar = GetComponent<Transform>();
        Rotation();
    }

    // Update is called once per frame
    void Update()
    {
        MoveTowards();
    }

    void MoveTowards()
    {
        Vector2 boarTransform = boar.transform.position;
        Vector2 targetTransform = target.transform.position;
        //przemieszczaj dzika w kierunku gracza
        if(spawner.shortTimeBtwSpawn==1.6f && speed <20)
        {
            speed += 0.25f;
        }
        transform.position = Vector2.MoveTowards(boarTransform, targetTransform, speed * Time.deltaTime);
    }

    void Rotation()
    {
        //w zależności od pozycji dzikia obróć jego teksturke
        if(transform.position.x < 0 && transform.position.y==0)
        {
            transform.Rotate(0, 0, 0, Space.World);
        }
        else if(transform.position.x == 0 && transform.position.y > 0)
        {
            transform.Rotate(0, 0, -90, Space.World);
        }
        else if(transform.position.x == 0 && transform.position.y < 0)
        {
            transform.Rotate(0, 0, 90, Space.World);
        }
        else if(transform.position.x > 0 && transform.position.y == 0)
        {
            transform.Rotate(0, 180, 0, Space.World);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

}
