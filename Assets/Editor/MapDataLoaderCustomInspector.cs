using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MapDataLoader))]
public class MapDataLoaderCustomInspector : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        MapDataLoader mapDataLoader = (MapDataLoader)target;

        //if (GUILayout.Button("Create Object Pool"))
        //{
        //    mapDataLoader.CreatePool();
        //}
        //else if(GUILayout.Button("Clear Object Pool"))
        //{
        //    mapDataLoader.ClearPool();
        //}
        if (GUILayout.Button("Load Data"))
        {
            mapDataLoader.LoadMapData();
        }
    }
}
