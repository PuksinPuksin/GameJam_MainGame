using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class SingleTon
{
    public static SingleTon Instance = null;

    void Awake()
    {
        if (Instance == null) Instance = this;
    }

    public void GameStart()
    {
        SceneManager.LoadScene("Ingame");
    }

    public void GameOver()
    {

    }

    public void Explain()
    {

    }

    public void OnMain()
    {
        SceneManager.LoadScene("Main");
    }

    public void OnQuit()
    {
        Application.Quit();
    }
}