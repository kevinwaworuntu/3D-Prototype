using System.IO;
using UnityEngine;

public class SettingsAudioSaveLoadJSON : ISaveLoad
{
    private SettingsAudioVolumeDataSO audioVolumeDataSO;
    public string path = "";
    public string persistentPath = "";

    public void SetAudioData()
    {
        audioVolumeDataSO = Resources.Load<SettingsAudioVolumeDataSO>("ScriptableObject/SettingsAudioVolume"); 
    }


    public void SetPaths()
    {
        path = Application.dataPath + Path.AltDirectorySeparatorChar + "SaveAudioSettingsData.json";
        persistentPath = Application.persistentDataPath + Path.AltDirectorySeparatorChar + "SaveAudioSettingsData.json";
    }

    public void Save()
    {
        string savePath = persistentPath;
        Debug.Log("Save Audio Data at " + savePath);
        string json = JsonUtility.ToJson(audioVolumeDataSO);
        Debug.Log(json);

        File.WriteAllText(savePath, json);
    }

    public void Load()
    {
        string json = File.ReadAllText(persistentPath);
        Debug.Log(json);
        JsonUtility.FromJsonOverwrite(json, audioVolumeDataSO);
        Debug.Log(audioVolumeDataSO.ToString());
    }
}
