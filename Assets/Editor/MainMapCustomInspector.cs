using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MainMapManager))]
public class MainMapCustomInspector : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        MainMapManager mainMapManager = (MainMapManager)target;
        if (GUILayout.Button("Generate Map"))
        {
            mainMapManager.GenerateMainMap();
        }
        else if (GUILayout.Button("Generate All Map Data"))
        {
            mainMapManager.GenerateAllMapData();
        }
    }
}
