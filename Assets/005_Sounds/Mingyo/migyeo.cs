using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class migyeo : MonoBehaviour
{
    [SerializeField] private SoundManager soundManager;

    /// <summary>
    /// [P]
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    /// 
    /// 


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SoundManager.Instance.PlayFXSound("FxSample");
        }
    }
}
