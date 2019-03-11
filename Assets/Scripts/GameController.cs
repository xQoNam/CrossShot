using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public int score = 0;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI loseScoreText;
    public TextMeshProUGUI highScoreText;
    private Player player; //used to check if the player is alive
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
            scoreText.text = "Score:  " + score.ToString(); //change score text displayed when player is playing
        }
        else
        {
            Destroy(scoreText);
        }
        
    }
}
