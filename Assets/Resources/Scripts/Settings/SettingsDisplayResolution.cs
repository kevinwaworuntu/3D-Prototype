using UnityEngine;

#region ...
/// <summary>
/// Personalize Display Resolution
/// </summary>
#endregion
public class SettingsDisplayResolution
{
    #region ...
    /// <summary>
    /// Set Display Resolution to Fullscreen
    /// </summary>
    #endregion
    public void Fullscreen()
    {
        Screen.fullScreen = true;
    }

    #region ...
    /// <summary>
    /// Set Display Resolution to Windowed (1336x768)
    /// </summary>
    #endregion
    public void Windowed()
    {
        Screen.SetResolution(1366, 768, false);
    }
 
    #region ...
    /// <summary>
    /// Set Display Resolution by value between 0-2
    /// </summary>
    /// <param value="x"></param>
    #endregion
    public void SetResolution(int x)
    {
        switch (x)
        {
            case 0:
                Screen.SetResolution(3840, 2160, true);
                break;
            case 1:
                Screen.SetResolution(1920, 1080, true);
                break;
            case 2:
                Windowed();
                break;
        }
    }
}
