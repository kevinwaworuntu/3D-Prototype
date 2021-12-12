using UnityEngine;
using UnityEngine.UI;

public class UIVolumeControl: MonoBehaviour
{
    [Header("Volume Control")]
    [SerializeField] private SettingsAudioVolumeDataSO volumeControl;

    [Header("Volume UI Slider")]
    [SerializeField] private Slider sliderMasterVolume, sliderOSTVolume, sliderSFXVolume;

    [Header("Test Change Slider Value")]
    [Range(0, 1)]
    [SerializeField] float sliderValue;
    private void Update()
    {
        SliderMasterVolume();
        SliderOSTVolume();
        SliderSFXVolume();
        //TestSliderValue();
    }

    void SliderMasterVolume()
    {
        volumeControl.masterVolume = sliderMasterVolume.value*100;
    }

    void SliderOSTVolume()
    {
        volumeControl.ostVolume = sliderOSTVolume.value*100;
    }

    void SliderSFXVolume()
    {
        volumeControl.sfxVolume = sliderSFXVolume.value*100;
    }

    public void ParseUIToScriptableObject()
    {
        sliderMasterVolume.value = volumeControl.masterVolume / 100;
        sliderOSTVolume.value = volumeControl.ostVolume / 100;
        sliderSFXVolume.value = volumeControl.sfxVolume / 100;
    }

    //void TestSliderValue()
    //{
    //    sliderMasterVolume.value = sliderValue;
    //}
}
