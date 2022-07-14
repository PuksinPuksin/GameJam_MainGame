using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpManager : MonoBehaviour
{
    public PPAnimation ppAnimation;
    [SerializeField] private GameObject filter = null;
    [SerializeField] private GameObject optionPanel;
    [SerializeField] private GameObject explainPanel;
    [SerializeField] private GameObject settingButton;
    public static bool settingOn;
    public static bool explainOn;


    public void OptionPopUpAnimation()
    {   
        if(settingOn == false)
        {
            ppAnimation.Animation(optionPanel);
            settingButton.gameObject.SetActive(false);
            settingOn = true;
            filter.SetActive(true);
        }
        else
        {
            filter.SetActive(false);
            optionPanel.SetActive(false);
            settingButton.gameObject.SetActive(true);
            settingOn = false;
        }
    }



    public void ExplainPopUpAnimation()
    {

        if (explainOn == false)
        {
            ppAnimation.Animation2(explainPanel);
            filter.SetActive(true);
            explainOn = true;
        }
        else
        {
            filter.SetActive(false);
            explainPanel.SetActive(false);
            explainOn = false;
        }
    }

}
