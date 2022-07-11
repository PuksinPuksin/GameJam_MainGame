using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Utill;

public class mmm : MonoBehaviour
{
    [SerializeField] private GameObject panel;

    private void Start()
    {
        panel.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Dotween.PopUpAnimation(panel);

        }
    }
}
