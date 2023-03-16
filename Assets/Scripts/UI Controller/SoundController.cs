using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SoundController : MonoBehaviour
{



    [SerializeField]
    AudioSource audioEffect, audioBackground;

    [SerializeField]
    Slider sdEffect, sdBackground;
    [SerializeField]
    GameObject panelSetting;


    // Start is called before the first frame update
    void Start()
    {
        panelSetting.active = (true);
        
        audioEffect.volume = PlayerPrefs.GetFloat("VLEffect", 1);
        audioBackground.volume = PlayerPrefs.GetFloat("VLBackground", 1);
        if (sdEffect)
        {
            sdEffect.value = PlayerPrefs.GetFloat("VLEffect", 1);
        }
        if (sdBackground)
        {
            sdBackground.value = PlayerPrefs.GetFloat("VLBackground", 1);
        }

        panelSetting.active = (false);
    }

    // Update is called once per frame
    void Update()
    {
        if (sdEffect && sdBackground)
        {
            audioEffect.volume = sdEffect.value;
            audioBackground.volume = sdBackground.value;
        }

    }

}
