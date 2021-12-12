using System.IO;
using UnityEngine;

[RequireComponent(typeof(UIVolumeControl))]
public class UISaveLoadAudio : MonoBehaviour
{
    [Header("Save Load Settings")]
    [SerializeField] private bool isUsingJson = true;
    private SettingsAudioSaveLoadJSON audioDataJSON;
    private SettingsAudioSaveLoadPlayerPrefs audioDataPlayerPrefs;
    [Header("UI Volume Control")]
    private UIVolumeControl uiVolumeControl;

    private void Start()
    {
        uiVolumeControl = GetComponent<UIVolumeControl>();

        if (isUsingJson)
        {
            audioDataJSON = new SettingsAudioSaveLoadJSON();
            audioDataJSON.SetAudioData();
            audioDataJSON.SetPaths();
            if (File.Exists(audioDataJSON.persistentPath)) LoadAudio();
        }
        else
        {
            audioDataPlayerPrefs = new SettingsAudioSaveLoadPlayerPrefs();
        }
    }

    public void SaveAudio()
    {
        if (isUsingJson) audioDataJSON.Save();
        else audioDataPlayerPrefs.Save();
    }

    public void LoadAudio()
    {
        if (isUsingJson) audioDataJSON.Load();
        else audioDataPlayerPrefs.Load();
        uiVolumeControl.ParseUIToScriptableObject();
    }
}
