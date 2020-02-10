using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsScript : MonoBehaviour
{
    #region Variables
    public AudioMixer mainAudio;
    #endregion Variables

    #region Settings, St. Ledger
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
        QualitySettings.SetQualityLevel(qualityInex);
    }
    #endregion Settings, St. Ledger

}
