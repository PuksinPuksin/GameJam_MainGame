using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoSingleton<LoadScene>
{
    
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

}
