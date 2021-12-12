using UnityEngine;

public class SettingsAudioSaveLoadPlayerPrefs : ISaveLoad
{
    private SettingsAudioVolumeDataSO volumeControl = Resources.Load<SettingsAudioVolumeDataSO>("ScriptableObject/SettingsAudioVolume");

    public void Save()
    {
        PlayerPrefs.SetFloat("MasterVolume", volumeControl.masterVolume);
        PlayerPrefs.SetFloat("OSTVolume", volumeControl.ostVolume);
        PlayerPrefs.SetFloat("SFXVolume", volumeControl.sfxVolume);
    }

    public void Load()
    {
       volumeControl.masterVolume =  PlayerPrefs.GetFloat("MasterVolume");
       volumeControl.ostVolume =  PlayerPrefs.GetFloat("OSTVolume");
       volumeControl.sfxVolume =  PlayerPrefs.GetFloat("SFXVolume");
    }
}
