using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameoverPopUp : MonoBehaviour
{
    [SerializeField] private GameObject button1 = null;
    [SerializeField] private GameObject button2 = null;

    public void GameoverPopUP()
    {
        transform.DOMoveY(0, 0.75f);
        button1.SetActive(false);
        button2.SetActive(false);
    }

    public void Asd()
    {
        Time.timeScale = 0;
    }

}