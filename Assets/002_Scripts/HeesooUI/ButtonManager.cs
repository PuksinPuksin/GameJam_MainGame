using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private Button buttonS;
    [SerializeField] private Button buttonL;
    private void Start()
    {

    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            buttonS.GetComponent<IButton>().Selected();
        }
        else
        {
            buttonS.GetComponent<IButton>().NoneSelected();
        }
    }
}
