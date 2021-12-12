using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ToggleStatus
{
    none = 0,
    generateMap = 1,
    generateMapPlusCoin = 2
};
public class MapGeneratorToggleStatus : MonoBehaviour
{
    public ToggleStatus toggleStatus;

    public void OnToggleClick()
    {
        ToggleClickCounter();
        ToggleClickStatus();
    }

    public void ToggleClickStatus()
    {
        switch (toggleStatus)
        {
            case ToggleStatus.none:
                gameObject.transform.GetChild(0).GetComponent<Image>().color = Color.white;
                break;
            case ToggleStatus.generateMap:
                gameObject.transform.GetChild(0).GetComponent<Image>().color = Color.black;
                break;
            case ToggleStatus.generateMapPlusCoin:
                gameObject.transform.GetChild(0).GetComponent<Image>().color = Color.red;
                break;
        }
    }

    private int ToggleClickCounter()
    {
        toggleStatus++;
        if ((int)toggleStatus > 2) toggleStatus = 0;
        return (int)toggleStatus;
    }

}
