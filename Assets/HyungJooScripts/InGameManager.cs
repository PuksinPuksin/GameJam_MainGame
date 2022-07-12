using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class InGameManager : MonoBehaviour
{
    [SerializeField] private Slider hpSlider;
    public PlayerManager playerManager;
    private void Update()
    {
        hpSlider.value = playerManager.Hp;
    }
    private void Start()
    {
        SceneManager.LoadScene("OptionScene", LoadSceneMode.Additive);
        
    }
}
