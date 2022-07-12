using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InGameManager : MonoBehaviour
{
    [SerializeField] private Slider hpSlider;
    public PlayerManager playerManager;
    private void Update()
    {
        hpSlider.value = playerManager.Hp;
    }
}
