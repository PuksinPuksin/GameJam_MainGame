using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerParent : MonoBehaviour
{
    public void OnLoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void OnLoadAdditiveScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName,LoadSceneMode.Additive);
    }
}

