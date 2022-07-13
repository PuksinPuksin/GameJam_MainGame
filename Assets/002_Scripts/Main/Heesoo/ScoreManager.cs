using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{

    public float currentTime;
    public float maxTime;
    public int score;
    public HyungJooPlayerManager hyungJooPlayerManager;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI gameOverScoreText;
    [SerializeField] private TextMeshProUGUI bestScoreText;

    private void Start()
    {
        hyungJooPlayerManager = GameObject.Find("PlayerManager").GetComponent<HyungJooPlayerManager>();
        score = 0;
        currentTime = 0f;
        maxTime = 1f;
    }

    public void ScoreUp()
    {
        if(currentTime > maxTime)
        {
            score += 100;
            currentTime = 0;
        }
    }
    public void BestScore()
    {
        if(score > PlayerPrefs.GetInt("HIGHSCORE"))
        {
            PlayerPrefs.SetInt("HIGHSCORE", score);
        }
        PlayerPrefs.SetInt("SCORE", score);
    }
    private void Update()
    {
        currentTime += Time.deltaTime;
        scoreText.text = "Score : " + score;
        gameOverScoreText.text = "Score : " + PlayerPrefs.GetInt("SCORE");
        bestScoreText.text = "BESTSCORE : " + PlayerPrefs.GetInt("HIGHSCORE");
        if (hyungJooPlayerManager.Hp <= 0.000001)
        {
            BestScore();
        }
        ScoreUp();

    }

}
