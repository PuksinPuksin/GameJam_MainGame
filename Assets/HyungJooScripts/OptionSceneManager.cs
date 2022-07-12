using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionSceneManager : MonoBehaviour
{
    public bool optionPanelOn;
    public bool soundPanelOn;
    [SerializeField] private GameObject soundPanel;
    [SerializeField] private GameObject optionPanel;

    private void Start()
    {
        soundPanelOn = false;
        soundPanel.SetActive(false);
        optionPanelOn = false;
        optionPanel.SetActive(false);

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnOption();
        }
    }
    public void OnOption()
    {
        if (optionPanelOn == true)
        {
            Time.timeScale = 1.0f;
            optionPanel.SetActive(false);
            optionPanelOn = false;
        }
        else
        {
            Time.timeScale = 0f;
            optionPanel.SetActive(true);
            optionPanelOn = true;
        }
    }
    public void OnSound()
    {
        if (soundPanelOn == true)
        {
            soundPanel.SetActive(false);
            soundPanelOn = false;
        }
        else
        {
            {
                soundPanel.SetActive(true);
                soundPanelOn = true;
            }
        }
    }
    public void OnQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit(); // 어플리케이션 종료
#endif

    }
    public void OnMainMenu()
    {
        SceneManager.LoadScene("Main");
    }
    public void OnRestart()
    {
        SceneManager.LoadScene("InGame");
    }

}