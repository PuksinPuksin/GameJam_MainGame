using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class InGameManager : MonoBehaviour
{
    [SerializeField] private Slider hpSlider;
    public HyungJooPlayerManager hyungJooPlayerManager;
    private void Update()
    {
        hpSlider.value = hyungJooPlayerManager.Hp;
    }
    private void Start()
    {
        SceneManager.LoadScene("OptionScene", LoadSceneMode.Additive);
        hyungJooPlayerManager = GameObject.Find("PlayerManager").GetComponent<HyungJooPlayerManager>();
    }
}
