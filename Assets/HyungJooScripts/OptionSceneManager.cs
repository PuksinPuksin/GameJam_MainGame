using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionSceneManager : SceneManagerParent
{
    public bool optionPanelOn;

    public bool soundPanelOn;
    [SerializeField] private GameObject soundPanel;
    [SerializeField] private GameObject optionPanel;
    [SerializeField] private GameObject filter = null;

    private void Start()
    {
        soundPanelOn = false;
        soundPanel.SetActive(false);
        optionPanelOn = false;
        optionPanel.SetActive(false);
        filter.SetActive(false);

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
            filter.SetActive(false);
            Time.timeScale = 1.0f;
            optionPanel.SetActive(false);
            optionPanelOn = false;
        }
        else
        {
            filter.SetActive(true);
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
            Application.Quit(); // ���ø����̼� ����
#endif

    }
    public void OnMainMenu()
    {
        SceneManager.LoadScene("Heesoo");
    }
    public void OnRestart()
    {
        SceneManager.LoadScene(gameObject.scene.name);
    }

}