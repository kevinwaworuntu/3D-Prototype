using UnityEngine;

public class MapMaker : MonoBehaviour
{
#if UNITY_EDITOR

    [Header("MAP STATUS FROM UI")]
    public MapGeneratorToggleStatus[] toogleStatus;

    [Header("EMPTY MAP DATA")]
    [Tooltip("Drag Map Data that will be Edited")]  [SerializeField] private MapDataSO mapDataSO;


    #region Designing Map Only
    [ContextMenu("Save Data To Scriptable Object")]
    public void SaveData()
    {
        if (mapDataSO.mapDataContainer.Count != 0) mapDataSO.mapDataContainer.Clear(); 

        for (int i = 0; i < toogleStatus.Length; i++)
        {
            switch (toogleStatus[i].toggleStatus)
            {
                case ToggleStatus.none:
                    mapDataSO.mapDataContainer.Add(MapStatus.none);
                    break;
                case ToggleStatus.generateMap:
                    mapDataSO.mapDataContainer.Add(MapStatus.generateMap);
                    break;
                case ToggleStatus.generateMapPlusCoin:
                    mapDataSO.mapDataContainer.Add(MapStatus.generateMapPlusCoin);
                    break;
            }
            #region ...
            //if (i % so_MapData.matrixLenght == 0)
            //{
            //    //Move One Line Down
            //    //This is Only Used for Making easier to read in JSON
            //}
            #endregion
        }
    }
    [ContextMenu("Import MapData from SO to UI")]
    public void RefreshUIData()
    {
        if (mapDataSO.mapDataContainer.Count > 0)
        {
            for (int i = 0; i < mapDataSO.mapDataContainer.Count; i++)
            {
                switch (mapDataSO.mapDataContainer[i])
                {
                    case MapStatus.none:
                        toogleStatus[i].toggleStatus = ToggleStatus.none;
                        toogleStatus[i].ToggleClickStatus();
                        break;
                    case MapStatus.generateMap:
                        toogleStatus[i].toggleStatus = ToggleStatus.generateMap;
                        toogleStatus[i].ToggleClickStatus();
                        break;
                    case MapStatus.generateMapPlusCoin:
                        toogleStatus[i].toggleStatus = ToggleStatus.generateMapPlusCoin;
                        toogleStatus[i].ToggleClickStatus();
                        break;
                }
            }
        }
    }
    [ContextMenu("Clear UI")]
    public void ClearUIData()
    {
        for (int i = 0; i < toogleStatus.Length; i++)
        {
            toogleStatus[i].toggleStatus = ToggleStatus.none;
            toogleStatus[i].GetComponent<MapGeneratorToggleStatus>().ToggleClickStatus();
        }
    }
    #endregion
#endif
}
