using UnityEngine;

public class HPHandler : MonoBehaviour
{
    [Header("Number of lives")]
    public int HPNumber;
    private Player player; //used to check if number of player lives

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
