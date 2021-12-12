using UnityEngine.Rendering.Universal;
using UnityEngine;

#region ...
/// <summary>
/// Set Anti Aliasing Mode
/// </summary>
#endregion
public class SettingsDisplayAntiAliasing : MonoBehaviour
{
    private UniversalAdditionalCameraData cameraData;

    private void Start()
    {
        cameraData = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<UniversalAdditionalCameraData>();
    }

    #region ...
    /// <summary>
    /// Set Anti Aliasing mode with value between 0 - 2
    /// </summary>
    /// <param value="x"> Input value between 0 - 2</param>
    #endregion
    public void SetAntiAliasing(int x)
    {
        switch (x)
        {
            case 0:
                AntiAliansingNone();
                break;
            case 1:
                AntiAliansingFXAA();
                break;
            case 2:
                AntiAliansingSMAA();
                break;
        }
    }
    #region ...
    /// <summary>
    /// Change Anti Aliasing mode to None
    /// </summary>
    #endregion
    public void AntiAliansingNone()
    {
        cameraData.antialiasing = AntialiasingMode.None;
    }
    #region ...
    /// <summary>
    /// Change Anti Aliasing mode to Fast Approximate Anti Aliasing(FXAA)
    /// </summary>
    #endregion
    public void AntiAliansingFXAA()
    {
        cameraData.antialiasing = AntialiasingMode.FastApproximateAntialiasing;
    }

    #region ...
    /// <summary>
    /// Change Anti Aliasing mode to Subpixel Morphological Anti aliAsing(SMAA)
    /// </summary>
    #endregion
    public void AntiAliansingSMAA()
    {
        cameraData.antialiasing = AntialiasingMode.SubpixelMorphologicalAntiAliasing;
    }
}
