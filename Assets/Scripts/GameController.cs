using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public int score = 0;
    private Player player;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI loseScoreText;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
    }
    private void Update()
    {
        SetScore();
    }

    public void SetScore()
    {
        loseScoreText.text= "YOUR SCORE:  " + score.ToString();
        if(player.HP!=0)
        {
            scoreText.text = "Score:  " + score.ToString();
        }
        else
        {
            Destroy(scoreText);
        }
        
    }
}
