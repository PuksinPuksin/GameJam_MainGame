using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{

    public float currentTime;
    public float maxTime;
    public int score;
    [SerializeField] private TextMeshProUGUI scoreText;

    private void Start()
    {
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
    private void Update()
    {
        currentTime += Time.deltaTime;
        scoreText.text = "Score : " + score;
        ScoreUp();

    }

}
