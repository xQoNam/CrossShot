using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoarSpawner : MonoBehaviour
{
    public int score = 0;
    public bool isPlaying = true;
    //pozycja góra dół
    Vector3 positionUpDown = new Vector3(0, 5.5f, 0);
    //pozycja prawa lewa
    Vector3 positionRightLeft = new Vector3(9.5f,0,0);
    private float timeBtwSpawn= 2;
    public float shortTimeBtwSpawn = 0;
    private float timeBtwFasterSpawn = 12;
    public GameObject boar;
    private Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        //wylosuj przypadkową liczbę
        Spawn();
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        Spawn();
        FasterSpawn();
    }

    void Spawn()
    {
        float number;
        Vector3 position = Vector3.zero;
        //odczekaj odpowiednią ilość czasu
        if (timeBtwSpawn <=0 && isPlaying)
        {
            //losuj przypadkową liczbę
            number = Random.Range(0, 4);
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
            Instantiate(boar, position, Quaternion.identity);
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
            player.startTimeBtwAttack = 0.2f;
        }
    }
}
