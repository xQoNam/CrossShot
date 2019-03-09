using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPHandler : MonoBehaviour
{
    private Player player;
    public int HPNumber;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        HideHealth(HPNumber);
    }

    void HideHealth(int HPNumber)
    {
        if(player.HP==HPNumber)
        {
            Destroy(this.gameObject);
        }
    }
}
