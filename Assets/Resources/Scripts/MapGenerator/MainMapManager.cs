using System.Collections;
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

    [Header("MAP DATA TO SPAWN")]
    [SerializeField] private GameObject mapDataToSpawn0;
    [SerializeField] private GameObject mapDataToSpawn1;
    [SerializeField] private GameObject mapDataToSpawn2;
    [SerializeField] private GameObject mapDataToSpawn3;
    [SerializeField] private GameObject mapDataParent0;
    [SerializeField] private GameObject mapDataParent1;
    [SerializeField] private GameObject mapDataParent2;
    [SerializeField] private GameObject mapDataParent3;

    #region GENERATE BRIDGE
    [ContextMenu("GenerateBridge")]
    private void GenerateBridgePool()
    {
        float spawnPosX = posXInitialValue;
        float spawnPosZ = posZInitialValue;

        for (int i = 0; i < matrixSize; i++)
        {
            for (int j = 0; j < matrixSize; j++)
            {  
                if (i == 10 || j == 10)
                {
                    bridgeList.Add(Instantiate<GameObject>(bridgeToSpawn, new Vector3(spawnPosX, 0, spawnPosZ), Quaternion.identity, transform));
                    bridgeList[(matrixSize * i) + j].name = $"bridge_({i},{j})";
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

        for (int i = 0; i < matrixSize; i++)
        {
            for (int j = 0; j < matrixSize; j++)
            {
                if (((matrixSize * i) + j) == 0)
                {
                    bridgeList[(matrixSize * i) + j] = Instantiate<GameObject>(mapDataToSpawn0, new Vector3(spawnPosX, 0, spawnPosZ), Quaternion.identity, mapDataParent0.transform);
                    bridgeList[(matrixSize * i) + j].name = $"MapData_({i},{j})";
                    bridgeList[(matrixSize * i) + j].GetComponent<MapGenerator>().GenerateMap();
                }
                else if (i == 0 && j == 11)
                {
                    bridgeList[(matrixSize * i) + j] = Instantiate<GameObject>(mapDataToSpawn1, new Vector3(spawnPosX, 0, spawnPosZ), Quaternion.identity, mapDataParent1.transform);
                    bridgeList[(matrixSize * i) + j].name = $"MapData_({i},{j})";
                    bridgeList[(matrixSize * i) + j].GetComponent<MapGenerator>().GenerateMap();
                }
                else if (i == 11 && j == 0)
                {
                    bridgeList[(matrixSize * i) + j] = Instantiate<GameObject>(mapDataToSpawn2, new Vector3(spawnPosX, 0, spawnPosZ), Quaternion.identity, mapDataParent2.transform);
                    bridgeList[(matrixSize * i) + j].name = $"MapData_({i},{j})";
                    bridgeList[(matrixSize * i) + j].GetComponent<MapGenerator>().GenerateMap();
                }
                else if (i == 11 && j == 11)
                {
                    bridgeList[(matrixSize * i) + j] = Instantiate<GameObject>(mapDataToSpawn3, new Vector3(spawnPosX, 0, spawnPosZ), Quaternion.identity, mapDataParent3.transform);
                    bridgeList[(matrixSize * i) + j].name = $"MapData_({i},{j})";
                    bridgeList[(matrixSize * i) + j].GetComponent<MapGenerator>().GenerateMap();
                }

                spawnPosX += posXIncrementValue;
            }
            spawnPosX = posXInitialValue;
            spawnPosZ -= posZIncrementValue;
        }
        spawnPosX = posZInitialValue;
    }
    #endregion

    public void GenerateMainMap()
    {
        GenerateBridgePool();
        SpawnMapData();
    }
}
