using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MapGenerator : MonoBehaviour
{
    [Header("MATRIX SIZE")]
    private int matrixSize;

    [Header("MAP DATA REFERENCE")]
    private MapDataLoader mapDataLoader;
    private MapMaker mapMaker;


    [Header("GAMEPLAY SCENE OR DESIGN SCENE")]
    [SerializeField] private bool isDataFromMapLoader = true;

    [Header("SPAWN OBJECT")]
    public GameObject groundToSpawn;
    public GameObject collectibleToSpawn;

    [Header("SPAWN POSITION")]
    public readonly float posXInitialValue = 0f;
    public readonly float posZInitialValue = 0f;
    public readonly float collectibleHeight = 1.5f;
    public readonly float posXIncrementValue = 1;
    public readonly float posZIncrementValue = 1;

    [Header("GAME OBJECT LIST")]
    public List<GameObject> groundList = new List<GameObject>();
    public List<GameObject> collectibleList = new List<GameObject>();

    private void Awake()
    {
        if (isDataFromMapLoader)
        {
            mapDataLoader = GetComponent<MapDataLoader>();
            matrixSize = (int)Mathf.Sqrt(mapDataLoader.mapDataSO.mapDataContainer.Count);
        }
        else
        {
            mapMaker = GetComponent<MapMaker>();
            matrixSize = mapMaker.matrixSize;
        }
    }

    [ContextMenu("De-Generate Map")]
    public void DegenerateMap()
    {
        ClearMapListData();
    }

    [ContextMenu("Generate Map")]
    public void GenerateMap()
    {
        CreatePool();
        CreateMapFromData(isDataFromMapLoader);
    }

    private void CreatePool()
    {
        float spawnPosX = posXInitialValue;
        float spawnPosZ = posZInitialValue;

        for (int i = 0; i < matrixSize; i++)
        {
            for (int j = 0; j < matrixSize; j++)
            {
                groundList.Add(Instantiate<GameObject>(groundToSpawn, transform));
                    groundList[(matrixSize * i) + j].transform.localPosition = new Vector3(spawnPosX, 0, spawnPosZ);
                    groundList[(matrixSize * i) + j].name = $"Ground_({i},{j})";
                    groundList[(matrixSize * i) + j].GetComponent<NavMeshSurface>().BuildNavMesh();
                    groundList[(matrixSize * i) + j].SetActive(false);

                    collectibleList.Add(Instantiate<GameObject>(collectibleToSpawn, groundList[(matrixSize * i) + j].transform));
                    collectibleList[(matrixSize * i) + j].transform.localPosition = new Vector3(0, collectibleHeight, 0);
                    collectibleList[(matrixSize * i) + j].name = $"Collectible_({j},{j})";
                    groundList[(matrixSize * i) + j].SetActive(false);
                spawnPosX += posXIncrementValue;
            }
            spawnPosX = posXInitialValue;
            spawnPosZ -= posZIncrementValue;
        }
        spawnPosX = posZInitialValue;
    }
    #region CREATE MAP FROM DATA
    private void CreateMapFromData(bool isDataFromMapLoader)
    {
        for (int i = 0; i < matrixSize; i++)
        {
            for (int j = 0; j < matrixSize; j++)
            {
                if (isDataFromMapLoader)
                {
                    switch (mapDataLoader.mapDataSO.mapDataContainer[(matrixSize * i) + j])
                    {
                        case MapStatus.none:
                            groundList[(matrixSize * i) + j].SetActive(false);
                            groundList[(matrixSize * i) + j].GetComponent<NavMeshModifier>().overrideArea = true;
                            groundList[(matrixSize * i) + j].GetComponent<NavMeshModifier>().area = 1;
                            collectibleList[(matrixSize * i) + j].SetActive(false);
                            break;
                        case MapStatus.generateMap:
                            groundList[(matrixSize * i) + j].SetActive(true);
                            groundList[(matrixSize * i) + j].GetComponent<NavMeshModifier>().overrideArea = false;
                            collectibleList[(matrixSize * i) + j].SetActive(false);
                            break;
                        case MapStatus.generateMapPlusCoin:
                            groundList[(matrixSize * i) + j].SetActive(true);
                            groundList[(matrixSize * i) + j].GetComponent<NavMeshModifier>().overrideArea = false;
                            collectibleList[(matrixSize * i) + j].SetActive(true);
                            break;
                    }
                }
                else
                {
                    switch (mapMaker.mapDataSO.mapDataContainer[(matrixSize * i) + j])
                    {
                        case MapStatus.none:
                            groundList[(matrixSize * i) + j].SetActive(false);
                            groundList[(matrixSize * i) + j].GetComponent<NavMeshModifier>().overrideArea = true;
                            groundList[(matrixSize * i) + j].GetComponent<NavMeshModifier>().area = 1;
                            collectibleList[(matrixSize * i) + j].SetActive(false);
                            break;
                        case MapStatus.generateMap:
                            groundList[(matrixSize * i) + j].SetActive(true);
                            groundList[(matrixSize * i) + j].GetComponent<NavMeshModifier>().overrideArea = false;
                            collectibleList[(matrixSize * i) + j].SetActive(false);
                            break;
                        case MapStatus.generateMapPlusCoin:
                            groundList[(matrixSize * i) + j].SetActive(true);
                            groundList[(matrixSize * i) + j].GetComponent<NavMeshModifier>().overrideArea = false;
                            collectibleList[(matrixSize * i) + j].SetActive(true);
                            break;
                    }
                }
            }
        }
    }
    #endregion
    #region CLEAR MAP FROM LIST
    private void ClearGroundList()
    {
        foreach (GameObject ground in groundList)
        {
            if (Application.isEditor) DestroyImmediate(ground);
            else Destroy(ground);
        }

        groundList.Clear();
    }

    private void ClearCollectibleList()
    {
        foreach (GameObject collectible in collectibleList)
        {
            if (Application.isEditor) DestroyImmediate(collectible);
            else Destroy(collectible);
        }

        collectibleList.Clear();
    }

    public void ClearMapListData()
    {
        ClearGroundList();
        ClearCollectibleList();
    }
    #endregion
}

