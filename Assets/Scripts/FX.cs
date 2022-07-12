using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class FX : MonoBehaviour
{
    public AudioMixer masterMixer;
    public Slider audioSlider;
    
    public void AudioControl()
    {
        float sound = audioSlider.value;

        if(sound == -40f)
        {
            masterMixer.SetFloat("FX", -80);
        }
        else
        {
            masterMixer.SetFloat("FX", sound);
        }
    }

    public void ToggleAudioVolume()
    {
        AudioListener.volume = AudioListener.volume == 0 ? 1 : 0;
    }
}
