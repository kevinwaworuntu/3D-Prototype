using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MainMapManager : MonoBehaviour
{
    [Header("SPAWN OBJECT")]
    public GameObject bridgeToSpawn;

    [Header("SPAWN POSITION")]
    private float posXInitialValue = 0.5f;
    private float posZInitialValue = 0.5f;
    private float posXIncrementValue = 1;
    private float posZIncrementValue = 1;

    [Header("GAME OBJECT LIST")]
    public int matrixSize;
    public List<GameObject> bridgeList = new List<GameObject>();
    public List<MapGenerator> mapGeneratorList = new List<MapGenerator>();

    [Header("MAP DATA TO SPAWN")]
    [SerializeField] private GameObject[] mapDataToSpawn;


    #region GENERATE BRIDGE
    [ContextMenu("GenerateBridge")]
    private void GenerateBridgePool()
    {
        float spawnPosX = posXInitialValue;
        float spawnPosZ = posZInitialValue;
        float matrixMiddleIndex = ((matrixSize - 1) / 2);
        for (int i = 0; i < matrixSize; i++)
        {
            for (int j = 0; j <    matrixSize; j++)
            {  
                if (i == matrixMiddleIndex || j == matrixMiddleIndex)
                {
                    if (i == matrixMiddleIndex - 8 || j == matrixMiddleIndex - 8)
                    {
                        //if (mapDataToSpawn.Length >= 1)
                        //{
                            bridgeList.Add(Instantiate<GameObject>(bridgeToSpawn, new Vector3(spawnPosX, 0, spawnPosZ), Quaternion.identity, transform));
                            bridgeList[(matrixSize * i) + j].name = $"bridge_({i},{j})";
                        //}
                    }
                    else if (i == matrixMiddleIndex - 3 || j == matrixMiddleIndex - 3)
                    {
                        //if (mapDataToSpawn.Length >= 2)
                        //{
                            bridgeList.Add(Instantiate<GameObject>(bridgeToSpawn, new Vector3(spawnPosX, 0, spawnPosZ), Quaternion.identity, transform));
                            bridgeList[(matrixSize * i) + j].name = $"bridge_({i},{j})";
                        //}
                    }
                    else if (i == matrixMiddleIndex + 3 || j == matrixMiddleIndex + 3)
                    {
                        //if (mapDataToSpawn.Length >= 3)
                        //{
                            bridgeList.Add(Instantiate<GameObject>(bridgeToSpawn, new Vector3(spawnPosX, 0, spawnPosZ), Quaternion.identity, transform));
                            bridgeList[(matrixSize * i) + j].name = $"bridge_({i},{j})";
                        //}
                    }
                    else if (i == matrixMiddleIndex + 8 || j == matrixMiddleIndex + 8)
                    {
                        //if (mapDataToSpawn.Length >= 4) 
                        //{
                            bridgeList.Add(Instantiate<GameObject>(bridgeToSpawn, new Vector3(spawnPosX, 0, spawnPosZ), Quaternion.identity, transform));
                            bridgeList[(matrixSize * i) + j].name = $"bridge_({i},{j})";
                        //}
                    }
                    else
                    {
                        bridgeList.Add(null);
                    }
                }
                else
                {
                    bridgeList.Add(null);
                }

                spawnPosX += posXIncrementValue;
            }
            spawnPosX = posXInitialValue;
            spawnPosZ -= posZIncrementValue;
        }
        spawnPosX = posZInitialValue;
    }
    #endregion
    #region SPAWN MAP DATA
    [ContextMenu("SpawnMapData")]
    private void SpawnMapData()
    {
        float spawnPosX = posXInitialValue;
        float spawnPosZ = posZInitialValue;
        int k = 0;
        for (int i = 0; i < matrixSize; i++)
        {
            for (int j = 0; j < matrixSize; j++)
            {
                if (i == 0 && j == 0)
                {
                    if (mapDataToSpawn.Length >= 1)
                    {
                        bridgeList[(matrixSize * i) + j] = Instantiate<GameObject>(mapDataToSpawn[k], new Vector3(spawnPosX, 0, spawnPosZ), Quaternion.identity, transform);
                        bridgeList[(matrixSize * i) + j].name = $"MapData_({i},{j})";
                        mapGeneratorList.Add(bridgeList[(matrixSize * i) + j].GetComponent<MapGenerator>());
                        k++;
                    }
                }
                else if (i == 0 && j == ((matrixSize / 2) + 1))
                {
                    if (mapDataToSpawn.Length >= 2)
                    {
                        bridgeList[(matrixSize * i) + j] = Instantiate<GameObject>(mapDataToSpawn[k], new Vector3(spawnPosX, 0, spawnPosZ), Quaternion.identity, transform);
                        bridgeList[(matrixSize * i) + j].name = $"MapData_({i},{j})";
                        mapGeneratorList.Add(bridgeList[(matrixSize * i) + j].GetComponent<MapGenerator>());
                        k++;
                    }
                }
                else if (i == ((matrixSize / 2) + 1) && j == 0)
                {
                    if (mapDataToSpawn.Length >= 3)
                    {
                        bridgeList[(matrixSize * i) + j] = Instantiate<GameObject>(mapDataToSpawn[k], new Vector3(spawnPosX, 0, spawnPosZ), Quaternion.identity, transform);
                        bridgeList[(matrixSize * i) + j].name = $"MapData_({i},{j})";
                        mapGeneratorList.Add(bridgeList[(matrixSize * i) + j].GetComponent<MapGenerator>());
                        k++;
                    }
                }
                else if (i == ((matrixSize / 2) + 1) && j == ((matrixSize / 2) + 1))
                {
                    if (mapDataToSpawn.Length >= 4)
                    {
                        bridgeList[(matrixSize * i) + j] = Instantiate<GameObject>(mapDataToSpawn[k], new Vector3(spawnPosX, 0, spawnPosZ), Quaternion.identity, transform);
                        bridgeList[(matrixSize * i) + j].name = $"MapData_({i},{j})";
                        mapGeneratorList.Add(bridgeList[(matrixSize * i) + j].GetComponent<MapGenerator>());
                        k++;
                    }
                }
                spawnPosX += posXIncrementValue;
            }
            spawnPosX = posXInitialValue;
            spawnPosZ -= posZIncrementValue;
        }
        spawnPosX = posZInitialValue;
        k = 0;
    }
    #endregion

    [ContextMenu("GenerateMainMap")]
    public void GenerateMainMap()
    {
        GenerateBridgePool();
        SpawnMapData();
        GenerateAllMapData();
        GetComponent<NavMeshSurface>().BuildNavMesh();
    }
    public void GenerateAllMapData()
    {
        foreach (MapGenerator mapGenerator in mapGeneratorList)
        {
            mapGenerator.GenerateMap();
        }
    }
}
