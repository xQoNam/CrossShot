using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float startTimeBtwAttack;
    public int lifes = 3;
    private float timeBtwAttack;
    public GameObject projectile;
    Vector3 positionHorizontal = new Vector3(0.4f, 0, 0);
    Vector3 positionVertical = new Vector3(0, 0.4f, 0);
    // Start is called before the first frame update
    void Start()
    {
        //Ustaw pozycje na 0.0.0
        transform.position = Vector3.zero;
        timeBtwAttack = -1;
    }

    // Update is called once per frame
    void Update()
    {
        Shot();
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
            lifes -= 1;
            if(lifes<=0)
            {
                Destroy(gameObject);
            }
        }
        
    }
}
