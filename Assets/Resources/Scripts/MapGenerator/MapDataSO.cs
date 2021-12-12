using System.Collections.Generic;
using UnityEngine;

public enum MapStatus
{
    none = 0,
    generateMap = 1,
    generateMapPlusCoin = 2
};

[CreateAssetMenu(fileName = "MapData_",menuName ="ScriptableObject/Map Data")]
public class MapDataSO : ScriptableObject
{
    [Header("MapData")]
    public List<MapStatus> mapDataContainer = new List<MapStatus>();
    
}
