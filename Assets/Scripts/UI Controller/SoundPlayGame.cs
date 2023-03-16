using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayGame : MonoBehaviour
{
    [SerializeField]
    AudioSource audioEffect, audioBackground;

    private void Start()
    {

        audioEffect.volume = PlayerPrefs.GetFloat("VLEffect", 1);
        audioBackground.volume = PlayerPrefs.GetFloat("VLBackground", 1);

    }
    private void Update()
    {
        Debug.Log("Volumn:" + audioBackground.volume);
    }
}
