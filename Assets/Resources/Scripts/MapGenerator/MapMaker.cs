using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class MapMaker : MonoBehaviour
{
    [Header("MATRIX SIZE")]
    public int matrixSize;

    [Header("EMPTY MAP DATA")]
    [Tooltip("Drag Map Data that will be Edited")] public MapDataSO mapDataSO;

    [Header("SPAWN TOGGLE OBJECT")]
    [SerializeField] private GameObject toggleToSpawn;

    [Header("SPAWN POSITION")]
    [SerializeField] private Transform parentCanvas;
    [SerializeField] private float spawnStartPosX = 0;
    [SerializeField] private float spawnStartPosY = 0;
    private float posXIncrementValue = 100;
    private float posYIncrementValue = 100;
    
    [Header("GAME OBJECT LIST")]
    public List<GameObject> toggleList = new List<GameObject>();
    public List<MapGeneratorToggleStatus> toogleStatus = new List<MapGeneratorToggleStatus>();

    private void Awake()
    {
        GenerateToggleObjectPool();
    }

    #region CREATE POOL
    private void GenerateToggleObjectPool()
    {
        for (int i = 0; i < matrixSize; i++)
        {
            for (int j = 0; j < matrixSize; j++)
            {
                toggleList.Add(Instantiate<GameObject>(toggleToSpawn, parentCanvas));
                toggleList[(matrixSize * i) + j].GetComponent<RectTransform>().localPosition = new Vector3(spawnStartPosX, spawnStartPosY);
                toggleList[(matrixSize * i) + j].name = $"Toggle_{(matrixSize * i) + j}";
                spawnStartPosX += posXIncrementValue;
            }
            spawnStartPosX = 0;
            spawnStartPosY -= posYIncrementValue;
        }
        spawnStartPosY = 0;
        RetrieveToggleStatus();
    }
    #endregion

    private void RetrieveToggleStatus()
    {
        for (int i = 0; i < toggleList.Count; i++)
        {
            toogleStatus.Add(toggleList[i].GetComponent<MapGeneratorToggleStatus>());
        }
    }

    public void SaveData()
    {
        if (mapDataSO.mapDataContainer.Count != 0) mapDataSO.mapDataContainer.Clear(); 
        for (int i = 0; i < toogleStatus.Count; i++)
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
        }
        EditorUtility.SetDirty(mapDataSO);
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
        for (int i = 0; i < toogleStatus.Count; i++)
        {
            toogleStatus[i].toggleStatus = ToggleStatus.none;
            toogleStatus[i].GetComponent<MapGeneratorToggleStatus>().ToggleClickStatus();
        }
    }

}
