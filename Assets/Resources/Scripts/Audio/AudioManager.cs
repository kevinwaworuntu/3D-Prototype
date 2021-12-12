using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Volume Control")]
    private AudioVolumeControl audioVolumeControl;

    private void Start()
    {
        audioVolumeControl = new AudioVolumeControl();
    }

    private void Update()
    {
        audioVolumeControl.VolumeControl();   
    }


}
