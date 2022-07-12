using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMove : MonoBehaviour
{
    // public PlayerHp playerHp;

    public void OnStart()
    {
        LoadScene.Instance.GameStart(); // 게임 스타트 버튼 함수
    }

    public void OnMain()
    {
        LoadScene.Instance.MainMenu(); // 메인 메뉴 버튼 함수
    }

    public void OnQuit()
    {
        Application.Quit(); // 어플리케이션 종료
        Debug.Log("11");
    }

    private void Start()
    {

    }

    private void Update()
    {
        Die();
    }

    public void Die()
    {
        /*if (playerHp.CurrentHp <= 0.0001)
        {
            LoadScene.Instance.GameOver();
        }*/
    }
}
