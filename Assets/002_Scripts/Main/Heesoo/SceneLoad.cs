using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoad : SceneManagerParent
{

    public void OnStart()
    {
        SingleTon.Instance.GameStart();
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

}
