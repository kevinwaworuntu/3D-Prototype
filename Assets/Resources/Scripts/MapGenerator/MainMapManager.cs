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
    public int mainMapMatrixSize;
    public List<GameObject> bridgeList = new List<GameObject>();
    public List<MapGenerator> mapGeneratorList = new List<MapGenerator>();

    [Header("MAP DATA TO SPAWN")]
    [SerializeField] private GameObject[] mapDataToSpawn;
    private int mapDataMatrixSize =  10;


    #region GENERATE BRIDGE
    private void GenerateBridgePool()
    {
        float spawnPosX = posXInitialValue;
        float spawnPosZ = posZInitialValue;
      
        for (int i = 0; i < mainMapMatrixSize; i++)
        {
            for (int j = 0; j < mainMapMatrixSize; j++)
            {
                bridgeList.Add(null);
                spawnPosX += posXIncrementValue;
            }
            spawnPosX = posXInitialValue;
            spawnPosZ -= posZIncrementValue;
        }
        spawnPosX = posZInitialValue;
    }


    [ContextMenu("GenerateBridge")]
    private void GenerateBridgeFromPool()
    {
        GenerateBridgePool();
        float spawnPosX = posXInitialValue;
        float spawnPosZ = posZInitialValue;
    
        int tempValue = 0;
        List<int> bridgeSpawnPos = new List<int>();

        for (int i = 0; i < Mathf.FloorToInt(mainMapMatrixSize / 10); i++)
        {
            if (i == 0) bridgeSpawnPos.Add(tempValue + mapDataMatrixSize);
            else
            {
                bridgeSpawnPos.Add(tempValue + mapDataMatrixSize + 1);
            }
            tempValue = bridgeSpawnPos[i];
            
            Debug.Log($"BridgeSpawnPos Value : { bridgeSpawnPos[i]}");
        }
        
        for (int i = 0; i < mainMapMatrixSize; i++)
        {
            for (int j = 0; j < mainMapMatrixSize; j++)
            {
                for (int k = 0; k < bridgeSpawnPos.Count;k++)
                {
                    if (i == bridgeSpawnPos[k] || j == bridgeSpawnPos[k])
                    {
                        if (k == 0)
                        {
                            if (i == bridgeSpawnPos[k] - 8 || i == bridgeSpawnPos[k] - 3)
                            {
                                if (mapDataToSpawn.Length > 1)
                                {
                                    bridgeList[(mainMapMatrixSize * i) + j] = Instantiate<GameObject>(bridgeToSpawn, new Vector3(spawnPosX, 0, spawnPosZ), Quaternion.identity, transform);
                                    bridgeList[(mainMapMatrixSize * i) + j].name = $"bridge_({i},{j})";
                                }
                            }
                            if (j == bridgeSpawnPos[k] - 8 || j == bridgeSpawnPos[k] - 3)
                            {
                                if (mapDataToSpawn.Length > 2)
                                {
                                    bridgeList[(mainMapMatrixSize * i) + j] = Instantiate<GameObject>(bridgeToSpawn, new Vector3(spawnPosX, 0, spawnPosZ), Quaternion.identity, transform);
                                    bridgeList[(mainMapMatrixSize * i) + j].name = $"bridge_({i},{j})";
                                }
                            }
                            if (i == bridgeSpawnPos[k] + 8 || i == bridgeSpawnPos[k] + 3)
                            {
                                if (mapDataToSpawn.Length > 3)
                                {
                                    bridgeList[(mainMapMatrixSize * i) + j] = Instantiate<GameObject>(bridgeToSpawn, new Vector3(spawnPosX, 0, spawnPosZ), Quaternion.identity, transform);
                                    bridgeList[(mainMapMatrixSize * i) + j].name = $"bridge_({i},{j})";
                                }
                            }
                            if (j == bridgeSpawnPos[k] + 8 || j == bridgeSpawnPos[k] + 3)
                            {
                                if (mapDataToSpawn.Length > 3)
                                {
                                    bridgeList[(mainMapMatrixSize * i) + j] = Instantiate<GameObject>(bridgeToSpawn, new Vector3(spawnPosX, 0, spawnPosZ), Quaternion.identity, transform);
                                    bridgeList[(mainMapMatrixSize * i) + j].name = $"bridge_({i},{j})";
                                }
                            }
                        }
                    }
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
        int a = 0;

        int tempValue = 0;
        List<int> mapDataSpawnPos = new List<int>();

        for (int i = 0; i < Mathf.FloorToInt(mainMapMatrixSize / 10); i++)
        {
            if (i == 0) mapDataSpawnPos.Add(tempValue);
            else
            {
                mapDataSpawnPos.Add(tempValue + mapDataMatrixSize + 1);
                tempValue = mapDataSpawnPos[i];
            }
        }

        for (int i = 0; i < mainMapMatrixSize; i++)
        {
            for (int j = 0; j < mainMapMatrixSize; j++)
            {
                for (int k = 0; k < mapDataSpawnPos.Count; k++)
                {
                    for (int l = 0; l < mapDataSpawnPos.Count; l++)
                    {
                        if (i == mapDataSpawnPos[k] && j == mapDataSpawnPos[l])
                        {
                            if (a < mapDataToSpawn.Length)
                            {
                                bridgeList[(mainMapMatrixSize * i) + j] = Instantiate<GameObject>(mapDataToSpawn[a], new Vector3(spawnPosX, 0, spawnPosZ), Quaternion.identity, transform);
                                bridgeList[(mainMapMatrixSize * i) + j].name = $"MapData_({i},{j})";
                                mapGeneratorList.Add(bridgeList[(mainMapMatrixSize * i) + j].GetComponent<MapGenerator>());
                                a++;
                            }
                        }
                    }
                }
                spawnPosX += posXIncrementValue;
            }
            spawnPosX = posXInitialValue;
            spawnPosZ -= posZIncrementValue;
        }
        spawnPosX = posZInitialValue;
        a = 0;
    }
    #endregion

    [ContextMenu("GenerateMainMap")]
    public void GenerateMainMap()
    {
        GenerateBridgeFromPool();
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
