using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoarSpawner : MonoBehaviour
{
    [Header("Types of enemies")]
    public GameObject boar;
    public GameObject grayGhost;
    public GameObject whiteGhost;
    private float timeBtwSpawn = 1.25f; //seconds left to spawn new enemy
    private float shortTimeBtwSpawn = 0; //amount of time for which respawn is shortened 
    private float timeBtwFasterSpawn = 12; //when this reach 0 timeBtwSpawn will be reduced by shortTimeBtwSpawn
    private Vector3 positionUpDown = new Vector3(0, 5.5f, 0); //Vertical position of respawn
    private Vector3 positionRightLeft = new Vector3(9.5f, 0, 0); //Horizontal positizion of respawn
    private Player player; //used to change player attack speed when enemies are spawning realy fast
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        Spawn();
        FasterSpawn();
    }
    //spawn randomly chosed enemies on random positions
    void Spawn()
    {
        Vector3 position = Vector3.zero;
        if (timeBtwSpawn <=0)
        {
            int positionOfEnemy = Random.Range(0, 4);
            int enemyID = Random.Range(0, 3);

            if (positionOfEnemy==0)
            {
                position = positionUpDown;
            }
            else if (positionOfEnemy==1)
            {
                position = positionRightLeft;
            }
            else if (positionOfEnemy==2)
            {
                position = -positionUpDown;
            }
            else if (positionOfEnemy==3)
            {
                position = -positionRightLeft;
            }

            if(enemyID==0)
            {
                Instantiate(boar, position, Quaternion.identity);
            }
            else if (enemyID==1)
            {
                Instantiate(whiteGhost, position, Quaternion.identity);
            }
            if (enemyID==2)
            {
                Instantiate(grayGhost, position, Quaternion.identity);
            }
            

            timeBtwSpawn = 2 - shortTimeBtwSpawn;
        }
        else
        {
            timeBtwSpawn -= Time.deltaTime;
        }
    }
    //reduce spawn cooldown after every 12 seconds by 0.4 second until it will be reduced by 1.6 second, after that make player shot faster
    void FasterSpawn()
    {
        timeBtwFasterSpawn -= Time.deltaTime;

        if(timeBtwFasterSpawn<=0 && shortTimeBtwSpawn<1.6)
        {
            timeBtwFasterSpawn = 12;
            shortTimeBtwSpawn += 0.4f;
        }
        else if(shortTimeBtwSpawn>=1.6)
        {
            player.startTimeBtwAttack = 0.1f;
        }
    }
}
