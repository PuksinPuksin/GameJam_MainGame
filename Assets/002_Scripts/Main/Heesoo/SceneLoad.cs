using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : SceneManagerParent
{

    public void OnStart()
    {
        SceneManager.LoadScene("IngameSeokPhone");
    }

    public void OnExplain()
    {

    }

    public void OnSetting()
    {

    }

    public void OnQuit()
    {
        Application.Quit();
        Debug.Log("111");
    }

    public void OnMain()
    {
        SceneManager.LoadScene("Heesoo");
    }
}
