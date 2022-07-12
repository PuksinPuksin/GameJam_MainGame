using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMove : MonoBehaviour
{
    
    
    public void OnStart()
    {
        LoadScene.Instance.GameStart();
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

}
