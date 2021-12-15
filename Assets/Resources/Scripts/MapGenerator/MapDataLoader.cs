using System.Collections.Generic;
using UnityEngine;

public class MapDataLoader : MonoBehaviour
{
    [Header("MAP DATA")]
    public MapDataSO mapDataSO;
    public int currentLevel;
 
    [ContextMenu("Load Map Data")]
    public void LoadMapData()
    {
        mapDataSO = Resources.Load<MapDataSO>($"ScriptableObject/MapData/MapData_{currentLevel}");
    }
}
