using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//script for slider in settings. One slider for music volume, second - sound volume
public class SliderController : MonoBehaviour
{
    public Slider slider;
    
    public float oldVolume;
    
    public string PrefsName;

    void Start()
    {
        slider.value = 0.2f;
        oldVolume = 0.1f;
        if (PlayerPrefs.HasKey(PrefsName))
        {
            slider.value = PlayerPrefs.GetFloat(PrefsName);
        }
    }

    //saving volume value if there is difference between slider.volume & currentvolume of the audiosource
    void Update()
    {
        if(oldVolume != slider.value)
        {
            PlayerPrefs.SetFloat(PrefsName, slider.value);
            PlayerPrefs.Save();
            oldVolume = slider.value;
        }
    }
}
