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
    private int healthPoints = 1;
    public bool moveFaster = false;
    public bool isTank = false;
    public bool shouldRotate = false;
    private BoarSpawner spawner;
    private GameController score;

    // Start is called before the first frame update
    void Start()
    {
        spawner = FindObjectOfType<BoarSpawner>();
        //pobierz pozycję dzika
        boar = GetComponent<Transform>();
        score = FindObjectOfType<GameController>();
        Rotation();
        if (isTank)
        {
            healthPoints = 2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        MoveTowards();
        if(moveFaster)
        {
            MoveFaster();
        }
    }

    void MoveTowards()
    {
        Vector2 boarTransform = boar.transform.position;
        Vector2 targetTransform = target.transform.position;
        //przemieszczaj dzika w kierunku gracza
        transform.position = Vector2.MoveTowards(boarTransform, targetTransform, speed * Time.deltaTime);
    }

    void Rotation()
    {
        if (shouldRotate)
        {
            //w zależności od pozycji dzikia obróć jego teksturke
            if (transform.position.x < 0 && transform.position.y == 0)
            {
                transform.Rotate(0, 0, 0, Space.World);
            }
            else if (transform.position.x == 0 && transform.position.y > 0)
            {
                transform.Rotate(0, 0, -90, Space.World);
            }
            else if (transform.position.x == 0 && transform.position.y < 0)
            {
                transform.Rotate(0, 0, 90, Space.World);
            }
            else if (transform.position.x > 0 && transform.position.y == 0)
            {
                transform.Rotate(0, 180, 0, Space.World);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
        else if(collision.CompareTag("Projectile"))
        {
            healthPoints--;
            if(healthPoints==0)
            {
                ScoreHandler();
                Destroy(gameObject);
            }         
        }
    }
    
    private void MoveFaster()
    {
        if (speed < 10)
        {
            speed += 0.25f;
        }
    }
    private void ScoreHandler()
    {
        if(moveFaster)
        {
            score.score += 3;
        }
        else if(isTank)
        {
            score.score += 2;
        }
        else
        {
            score.score += 1;
        }
    }

    
}
