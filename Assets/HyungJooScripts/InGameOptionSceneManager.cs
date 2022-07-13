using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameOptionSceneManager : MonoBehaviour
{
    public GameObject optionButton;
    public bool optionPanelOn;
    [SerializeField] private GameObject optionPanel;
    private void Start()
    {
        Time.timeScale = 1.0f;
        optionButton.SetActive(true);
        optionPanelOn = true;
        optionPanel.SetActive(false);
    }
    public void OnOption2()
    {
        if (optionPanelOn == true)
        {
            Time.timeScale = 0f;
            optionButton.SetActive(false);
            optionPanel.SetActive(true);
            optionPanelOn = false;
        }
        else
        {
            Time.timeScale = 1.0f;
            optionButton.SetActive(true);
            optionPanel.SetActive(false);
            optionPanelOn = true;
        }
    }
}
