using UnityEngine.UI;
using UnityEngine;

public class UIDisplaySettings : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private SettingsDisplayAntiAliasing displayAntiAliasing;
    private SettingsDisplayResolution displayResolution;

    [Header("Dropdown")]
    [SerializeField] private Dropdown dropdownDisplayResolution;
    [SerializeField] private Dropdown dropdownAntiAliasing;


    private void Start()
    {
        displayResolution = new SettingsDisplayResolution();

        DropdownItemSelectedDR(dropdownDisplayResolution);
        dropdownDisplayResolution.onValueChanged.AddListener(delegate { DropdownItemSelectedDR(dropdownDisplayResolution); });

        DropdownItemSelectedAA(dropdownAntiAliasing);
        dropdownAntiAliasing.onValueChanged.AddListener(delegate { DropdownItemSelectedAA(dropdownAntiAliasing); });
    }

    public void DropdownItemSelectedDR(Dropdown dropdown)
    {
        displayResolution.SetResolution(dropdown.value);
    }
    public void DropdownItemSelectedAA(Dropdown dropdown)
    {
        displayAntiAliasing.SetAntiAliasing(dropdown.value);
    }
}
