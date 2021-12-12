using UnityEngine;

public class AudioVolumeControl 
{
    private SettingsAudioVolumeDataFunctionSO volumeControl = Resources.Load<SettingsAudioVolumeDataFunctionSO>("ScriptableObject/AudioData/SettingsAudioVolume");
    #region ...
    /// <summary>
    /// Contains Refence to All Volume Control Settings
    /// </summary>
    #endregion
    public void VolumeControl()
    {
        volumeControl.MasterVolumeControl();
        volumeControl.MasterMute();
        volumeControl.OSTVolumeControl();
        volumeControl.OSTMute();
        volumeControl.SFXVolumeControl();
        volumeControl.SFXMute();
    }
}
