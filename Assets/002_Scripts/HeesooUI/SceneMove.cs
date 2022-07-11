using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utill;

public class SceneMove : MonoBehaviour
{
    // public PlayerHp playerHp;
    [SerializeField] private GameObject explainPanel;
    public static bool explainPanelOn;
    private void Start()
    {
    }
    public void OnStart()
    {
        LoadScene.Instance.GameStart(); // ���� ��ŸƮ ��ư �Լ�
    }

    public void OnMain()
    {
        LoadScene.Instance.MainMenu(); // ���� �޴� ��ư �Լ�
    }
    public void OnExplain()
    {
        if(explainPanelOn == true)
        {
            explainPanel.gameObject.SetActive(false);
        }
        else
        {
            Dotween.PopUpAnimation(explainPanel);
        }
    }
    public void OnQuit()
    {
        Application.Quit(); // ���ø����̼� ����
        Debug.Log("11");
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
