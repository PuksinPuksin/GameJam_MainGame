using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoSingleton<LoadScene>
{

    public void GameStart()
    {
        SceneManager.LoadScene("InGame");
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main");
    }

}
