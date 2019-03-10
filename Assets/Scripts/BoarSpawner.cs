using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoarSpawner : MonoBehaviour
{
    //pozycja góra dół
    Vector3 positionUpDown = new Vector3(0, 5.5f, 0);
    //pozycja prawa lewa
    Vector3 positionRightLeft = new Vector3(9.5f,0,0);
    private float timeBtwSpawn= 2;
    public float shortTimeBtwSpawn = 0;
    private float timeBtwFasterSpawn = 12;
    public GameObject boar;
    public GameObject grayGhost;
    public GameObject whiteGhost;
    private Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        //wylosuj przypadkową liczbę
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        Spawn();
        FasterSpawn();
    }

    void Spawn()
    {
        Vector3 position = Vector3.zero;
        //odczekaj odpowiednią ilość czasu
        if (timeBtwSpawn <=0)
        {
            //losuj przypadkową liczbę
            int number = Random.Range(0, 4);
            int enemyID = Random.Range(0, 3);
            //dobierz pozycję według przypadkowej liczby
            if (number==0)
            {
                position = positionUpDown;
            }
            else if (number==1)
            {
                position = positionRightLeft;
            }
            else if (number==2)
            {
                position = -positionUpDown;
            }
            else if (number==3)
            {
                position = -positionRightLeft;
            }
            //stwórz dzika na pozycji dobranej na podstawie przypadkowej liczby
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
    void FasterSpawn()
    {
        timeBtwFasterSpawn -= Time.deltaTime;
        if(timeBtwFasterSpawn<=0 && shortTimeBtwSpawn<1.6)
        {
            timeBtwFasterSpawn = 12;
            shortTimeBtwSpawn += 0.4f;
        }
        if(shortTimeBtwSpawn>=1.6)
        {
            player.startTimeBtwAttack = 0.1f;
        }
    }
}
