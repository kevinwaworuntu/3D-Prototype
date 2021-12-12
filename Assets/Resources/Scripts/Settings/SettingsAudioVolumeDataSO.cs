using UnityEngine;
using UnityEngine.Audio;

public class SettingsAudioVolumeDataSO : ScriptableObject
{
    [Header("Audio Mixer")]
    public AudioMixer audioMixer;

    [Header("Master Volume")]
    [Range(0, 100)]
    public float masterVolume;
    public bool masterMute;
    protected bool isMasterMuteOn;
    protected float masterVolumeTemp;

    [Header("OST Volume")]
    [Range(0, 100)]
    public float ostVolume;
    public bool ostMute;
    protected bool isOstMuteOn;
    protected float dB_OstTemp;
    protected float ostVolumeTemp;

    [Header("SFX Volume")]
    [Range(0, 100)]
    public float sfxVolume;
    public bool sfxMute;
    protected bool isSfxMuteOn;
    protected float dB_SfxTemp;
    protected float sfxVolumeTemp;

    public const float dB_Lowest = -80.0f;
}
