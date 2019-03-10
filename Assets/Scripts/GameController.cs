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
    public TextMeshProUGUI highScoreText;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        highScoreText.text = "HIGH SCORE:" + PlayerPrefs.GetInt("HighScore", 0).ToString();
    }
    private void Update()
    {
        SetScore();
    }

    public void SetScore()
    {
        loseScoreText.text= "YOUR SCORE:  " + score.ToString();
        if(score > PlayerPrefs.GetInt("HighScore",0))
        {
            PlayerPrefs.SetInt("HighScore", score);
            highScoreText.text ="HIGH SCORE: " + score.ToString();
        }
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
