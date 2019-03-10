using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public int score = 0;
    public TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    private void Update()
    {
        SetScore();
    }

    public void SetScore()
    {
        scoreText.text = "Score:  " + score.ToString();
    }
}
