using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISoundSample : MonoBehaviour
{
    public Slider masterSlider;
    public Slider bgmSlider;
    public Slider fxSlider;

    public Button fxBtn;

    private List<Slider> sliders;

    private void Start()
    {
        sliders = new List<Slider>
        {
            masterSlider,
            bgmSlider,
            fxSlider
        };

        sliders.ForEach((x) =>
        x.onValueChanged.AddListener((value) =>
        {
            x.value = value;
            AdjustVolumes();
        }));
    
        SoundManager.Instance.PlayBGMSound("BGMSample");
        fxBtn.onClick.AddListener(() => SoundManager.Instance.PlayFXSound("FxSample"));
    }

    private void AdjustVolumes()
    {
        SoundManager.Instance.AdjustMasterVolume(masterSlider.value);
        SoundManager.Instance.AdjustBGMVolume(bgmSlider.value);
        SoundManager.Instance.AdjustFxVoulme(fxSlider.value);
    }
}
