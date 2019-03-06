using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioSource enemyHit;
    public void EnemyHit()
    {
        enemyHit.Play();
    }
}
