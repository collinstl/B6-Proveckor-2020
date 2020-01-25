using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsScript : MonoBehaviour
{
    public AudioMixer mainAudio;

    public void SetVolume(float volume)
    {
        mainAudio.SetFloat("volume", volume);
    }

    public void FullScreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }

    public void SetQuality(int qualityInex)
    {

    }

}
