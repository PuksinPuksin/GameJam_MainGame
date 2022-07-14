using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : SceneManagerParent
{

    public void OnStart()
    {
        SceneManager.LoadScene(gameObject.scene.name);
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
    }

    public void OnMain()
    {
        SceneManager.LoadScene("Heesoo");
    }
}
