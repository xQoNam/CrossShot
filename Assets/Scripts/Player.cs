using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float startTimeBtwAttack;
    public int HP = 4;
    private float timeBtwAttack;
    private SoundController soundController;
    public GameObject projectile;
    public GameObject loseScreen;
    private BoarSpawner boarSpawner;
    Vector3 positionHorizontal = new Vector3(0.4f, 0, 0);
    Vector3 positionVertical = new Vector3(0, 0.4f, 0);
    // Start is called before the first frame update
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

    void Shot()
    {
        //jeżeli nie ma cd to strzelaj zależnie od wciśniętego klawisza
        if(timeBtwAttack <= 0)
        {
            if(Input.GetKeyDown(KeyCode.W))
            {
                //strzelaj do góry
                Instantiate(projectile, positionVertical, Quaternion.identity);
                timeBtwAttack = startTimeBtwAttack;
            }
            if(Input.GetKeyDown(KeyCode.S))
            {
                //strzelaj na dół
                Instantiate(projectile, -positionVertical, Quaternion.identity);
                timeBtwAttack = startTimeBtwAttack;
            }
            if(Input.GetKeyDown(KeyCode.D))
            {
                //strzelaj w prawo
                Instantiate(projectile, positionHorizontal, Quaternion.identity);
                timeBtwAttack = startTimeBtwAttack;
            }
            if(Input.GetKeyDown(KeyCode.A))
            {
                //strzelaj w lewo
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
