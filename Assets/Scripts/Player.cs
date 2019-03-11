using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Statistics")]
    public float startTimeBtwAttack; //attack speed
    public int HP = 4;
    [Header("References")]
    public GameObject projectile; //used to instantiate projectile
    public GameObject loseScreen; //used to turn ON lose screen when player is dead
    private float timeBtwAttack; //attack speed aswell 
    private SoundController soundController; //used to play sounds on collision with enemy
    private BoarSpawner boarSpawner; //used to stop spawning enemies after death
    //positions of projectiles after spawn
    private Vector3 positionHorizontal = new Vector3(0.4f, 0, 0);
    private Vector3 positionVertical = new Vector3(0, 0.4f, 0);

    void Start()
    {
        soundController = FindObjectOfType<SoundController>();
        boarSpawner = FindObjectOfType<BoarSpawner>();
        timeBtwAttack = -1;
    }

    // Update is called once per frame
    void Update()
    {
        Shot();
        LifeHandler();
    }

    //instantiate projectiles
    void Shot()
    {

        if(timeBtwAttack <= 0)
        {
            if(Input.GetKeyDown(KeyCode.W)) //shot up
            {
                Instantiate(projectile, positionVertical, Quaternion.identity);
                timeBtwAttack = startTimeBtwAttack;
            }
            if(Input.GetKeyDown(KeyCode.S)) //shot down
            {
                Instantiate(projectile, -positionVertical, Quaternion.identity);
                timeBtwAttack = startTimeBtwAttack;
            }
            if(Input.GetKeyDown(KeyCode.D)) //shot right
            {
                Instantiate(projectile, positionHorizontal, Quaternion.identity);
                timeBtwAttack = startTimeBtwAttack;
            }
            if(Input.GetKeyDown(KeyCode.A)) //shot left
            {
                Instantiate(projectile, -positionHorizontal, Quaternion.identity);
                timeBtwAttack = startTimeBtwAttack;
            }
        }
        else if(timeBtwAttack > 0)
        {
            timeBtwAttack -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            HP -= 1;
            soundController.playerHit.Play();
        }
        
    }
    //Handle player's death
    private void LifeHandler()
    {
        if (HP <= 0)
        {
            Destroy(gameObject);
            loseScreen.SetActive(true);
            Destroy(boarSpawner);
        }
    }
}
