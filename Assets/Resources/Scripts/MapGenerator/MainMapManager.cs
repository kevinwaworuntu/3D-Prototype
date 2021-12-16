using System.Collections.Generic;
using UnityEngine;

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
    [SerializeField] private GameObject[] mapDataParent;


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
                        bridgeList.Add(Instantiate<GameObject>(bridgeToSpawn, new Vector3(spawnPosX, 0, spawnPosZ), Quaternion.identity, transform));
                        bridgeList[(matrixSize * i) + j].name = $"bridge_({i},{j})";
                    }
                    else if (i == matrixMiddleIndex - 3 || j == matrixMiddleIndex - 3)
                    {
                        bridgeList.Add(Instantiate<GameObject>(bridgeToSpawn, new Vector3(spawnPosX, 0, spawnPosZ), Quaternion.identity, transform));
                        bridgeList[(matrixSize * i) + j].name = $"bridge_({i},{j})";
                    }
                    else if(i == matrixMiddleIndex + 3 || j == matrixMiddleIndex + 3)
                    {
                        bridgeList.Add(Instantiate<GameObject>(bridgeToSpawn, new Vector3(spawnPosX, 0, spawnPosZ), Quaternion.identity, transform));
                        bridgeList[(matrixSize * i) + j].name = $"bridge_({i},{j})";
                    }
                    else if (i == matrixMiddleIndex + 8 || j == matrixMiddleIndex + 8)
                    {
                        bridgeList.Add(Instantiate<GameObject>(bridgeToSpawn, new Vector3(spawnPosX, 0, spawnPosZ), Quaternion.identity, transform));
                        bridgeList[(matrixSize * i) + j].name = $"bridge_({i},{j})";
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
                    bridgeList[(matrixSize * i) + j] = Instantiate<GameObject>(mapDataToSpawn[k], new Vector3(spawnPosX, 0, spawnPosZ), Quaternion.identity, mapDataParent[k].transform);
                    bridgeList[(matrixSize * i) + j].name = $"MapData_({i},{j})";
                    mapGeneratorList.Add(bridgeList[(matrixSize * i) + j].GetComponent <MapGenerator>());
                    k++;
                    //bridgeList[(matrixSize * i) + j].GetComponent<MapGenerator>().GenerateMap();
                }
                else if (i == 0 && j == ((matrixSize / 2) + 1))
                {
                    bridgeList[(matrixSize * i) + j] = Instantiate<GameObject>(mapDataToSpawn[k], new Vector3(spawnPosX, 0, spawnPosZ), Quaternion.identity, mapDataParent[k].transform);
                    bridgeList[(matrixSize * i) + j].name = $"MapData_({i},{j})";
                    mapGeneratorList.Add(bridgeList[(matrixSize * i) + j].GetComponent<MapGenerator>());
                    k++;
                    //bridgeList[(matrixSize * i) + j].GetComponent<MapGenerator>().GenerateMap();
                }
                else if (i == ((matrixSize / 2) + 1) && j == 0)
                {
                    bridgeList[(matrixSize * i) + j] = Instantiate<GameObject>(mapDataToSpawn[k], new Vector3(spawnPosX, 0, spawnPosZ), Quaternion.identity, mapDataParent[k].transform);
                    bridgeList[(matrixSize * i) + j].name = $"MapData_({i},{j})";
                    mapGeneratorList.Add(bridgeList[(matrixSize * i) + j].GetComponent<MapGenerator>());
                    k++;
                    //bridgeList[(matrixSize * i) + j].GetComponent<MapGenerator>().GenerateMap();
                }
                else if (i == ((matrixSize / 2) + 1) && j == ((matrixSize / 2) + 1))
                {
                    bridgeList[(matrixSize * i) + j] = Instantiate<GameObject>(mapDataToSpawn[k], new Vector3(spawnPosX, 0, spawnPosZ), Quaternion.identity, mapDataParent[k].transform);
                    bridgeList[(matrixSize * i) + j].name = $"MapData_({i},{j})";
                    mapGeneratorList.Add(bridgeList[(matrixSize * i) + j].GetComponent<MapGenerator>());
                    k++;
                    //bridgeList[(matrixSize * i) + j].GetComponent<MapGenerator>().GenerateMap();
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
    }
    [ContextMenu("Generate All Map Data")]
    public void GenerateAllMapData()
    {
        foreach (MapGenerator mapGenerator in mapGeneratorList)
        {
            mapGenerator.GenerateMap();
        }
    }
}
