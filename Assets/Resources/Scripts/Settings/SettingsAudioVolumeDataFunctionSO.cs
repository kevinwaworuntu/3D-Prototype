using UnityEngine;

#region ...
/// <summary>
/// Set Audio Volume by Channel (Master,OST,SFX)
/// </summary>
#endregion
[CreateAssetMenu(fileName = "SettingsAudioVolume", menuName = "ScriptableObject/SettingsAudioVolume")]
public class SettingsAudioVolumeDataFunctionSO : SettingsAudioVolumeDataSO
{
    #region Master Volume
    #region ...
    /// <summary>
    ///  Change All Audio Volume by Audio Listene. Value between 0 - 100
    /// </summary>
    #endregion
    public void MasterVolumeControl()
    {
        float volume = masterVolume / 100;
        if (masterVolume >= 0 && masterVolume <= 100)
        {
            AudioListener.volume = volume;

            if (masterVolume > 0)
            {
                if (isMasterMuteOn)
                {
                    masterMute = false;
                    isMasterMuteOn = false;
                }
            }
        }

        else Debug.LogError("Volume must between 0 - 100");
    }

    #region ...
    /// <summary>
    ///  Mute All Audio
    /// </summary>
    #endregion
    public void MasterMute()
    {
        if (masterMute)
        {
            if (!isMasterMuteOn)
            {
                masterVolumeTemp = masterVolume;
                masterVolume = 0;

                isMasterMuteOn = true;
            }
        }
        else
        {
            if (isMasterMuteOn)
            {
                masterVolume = masterVolumeTemp;

                isMasterMuteOn = false;
            }
        }
    }
    #endregion
    #region OST Volume
    #region ...
    /// <summary>
    ///  Change OST Volume by Audio Mixer
    /// </summary>
    #endregion
    public void OSTVolumeControl()
    {
        float dB;
        if (ostVolume > 0)
        {
            dB = 20 * Mathf.Log10(ostVolume / 100);
            audioMixer.SetFloat("OSTVolume", dB);

            if (isOstMuteOn)
            {
                ostMute = false;
                isOstMuteOn = false;
            }
        }
        else
        {
            audioMixer.SetFloat("OSTVolume", dB_Lowest);
        }
    }
    #region ...
    /// <summary>
    ///  Mute All OST Audio
    /// </summary>
    #endregion
    public void OSTMute()
    {
        if (ostMute)
        {
            if (!isOstMuteOn)
            {
                audioMixer.GetFloat("OSTVolume", out dB_OstTemp);
                ostVolumeTemp = ostVolume;

                audioMixer.SetFloat("OSTVolume", dB_Lowest);
                ostVolume = 0;

                isOstMuteOn = true;
            }
        }
        else
        {
            if (isOstMuteOn)
            {
                audioMixer.SetFloat("OSTVolume", dB_OstTemp);
                ostVolume = ostVolumeTemp;

                isOstMuteOn = false;
            }
        }
    }

    #endregion
    #region SFX Volume
    #region ...
    /// <summary>
    ///  Change SFX Volume by Audio Mixer
    /// </summary>
    #endregion
    public void SFXVolumeControl()
    {
        float dB;
        if (sfxVolume > 0)
        {
            dB = 20 * Mathf.Log10(sfxVolume / 100);
            audioMixer.SetFloat("SFXVolume", dB);

            if (isSfxMuteOn)
            {
                sfxMute = false;
                isSfxMuteOn = false;
            }
        }
        else
        {
            audioMixer.SetFloat("SFXVolume", dB_Lowest);

        }
    }

    #region ...
    /// <summary>
    ///  Mute All SFX Audio
    /// </summary>
    #endregion
    public void SFXMute()
    {
        if (sfxMute)
        {
            if (!isSfxMuteOn)
            {
                audioMixer.GetFloat("SFXVolume", out dB_SfxTemp);
                sfxVolumeTemp = sfxVolume;

                audioMixer.SetFloat("SFXVolume", dB_Lowest);
                sfxVolume = 0;

                isSfxMuteOn = true;
            }
        }
        else
        {
            if (isSfxMuteOn)
            {
                audioMixer.SetFloat("SFXVolume", dB_SfxTemp);
                sfxVolume = sfxVolumeTemp;

                isSfxMuteOn = false;
            }
        }
    }

    #endregion
}
