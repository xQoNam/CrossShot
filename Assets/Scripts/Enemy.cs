using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Type of enemies")]
    public bool moveFaster = false;
    public bool isTank = false;
    [Header("Statistics")]
    public float speed;
    [SerializeField]private int healthPoints = 1;
    [Header("Player Position")]
    public Transform target; //player position
    private Transform boar; //enemy position
    private GameController score; //used to increase score

    void Start()
    {
        boar = GetComponent<Transform>();
        score = FindObjectOfType<GameController>();
        if (isTank)
        {
            healthPoints = 2;
        }
    }

    void FixedUpdate()
    {
        MoveTowards();
        if(moveFaster)
        {
            MoveFaster();
        }
    }
    //Moves enemy toward player position
    void MoveTowards()
    {
        Vector2 boarTransform = boar.transform.position;
        Vector2 targetTransform = target.transform.position;
        transform.position = Vector2.MoveTowards(boarTransform, targetTransform, speed * Time.deltaTime);
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
    //Score for killing enemy depends on their type
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
