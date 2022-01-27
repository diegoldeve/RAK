using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public Text scoreText;
    public Text highScoreText;
    int score = 0;
    int highscore = 0;
    void Start()
    {
        scoreText.text = "SCORE: " + score.ToString();
        highScoreText.text = "HIGH SCORE: " + highscore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Awake()
    {
        instance = this;
    }
    public void Add()
    {
        score +=1;
        scoreText.text = "SCORE: " + score.ToString();
    }
}
