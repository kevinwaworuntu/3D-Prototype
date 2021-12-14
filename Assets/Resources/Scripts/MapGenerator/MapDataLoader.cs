using System.Collections.Generic;
using UnityEngine;

public class MapDataLoader : MonoBehaviour
{
    [Header("SPAWN OBJECT")]
    public GameObject groundToSpawn;
    public GameObject collectibleToSpawn;

    [Header("SPAWN POSITION")]
    [SerializeField] private float posXInitialValue = 0.5f;
    [SerializeField] private float posZInitialValue = 0.5f;
    [SerializeField] private float collectibleHeight;
    private float posXIncrementValue = 1;
    private float posZIncrementValue = 1;
 
    [Header("GAME OBJECT LIST")]
    public int matrixSize;
    public List<GameObject> groundList = new List<GameObject>();
    public List<GameObject> collectibleList = new List<GameObject>();

    [Header("MAP DATA")]
    public MapDataSO mapDataSO;
    public int currentLevel;
 
    private void Awake()
    {
        if (groundList.Count == 0 && collectibleList.Count == 0)
        {
            GenerateGroundPool();
            GenerateCollectiblePool();
        }
    }
    #region CREATE POOL
    private void GenerateGroundPool()
    {
        float spawnPosX = posXInitialValue;
        float spawnPosZ = posZInitialValue;

        for (int i = 0; i < matrixSize; i++)
        {
            for (int j = 0; j < matrixSize; j++)
            {
                groundList.Add(Instantiate<GameObject>(groundToSpawn, new Vector3(spawnPosX, 0, spawnPosZ), Quaternion.identity, transform));
                groundList[(matrixSize * i) + j].name = $"Ground_{(matrixSize * i) + j}";
                groundList[(matrixSize * i) + j].SetActive(false);
                
                
                spawnPosX += posXIncrementValue;
            }
            spawnPosX = posXInitialValue;
            spawnPosZ -= posZIncrementValue;
        }
        spawnPosX = posZInitialValue;
    }   
    private void GenerateCollectiblePool()
    {
        float spawnPosX = posXInitialValue;
        float spawnPosZ = posZInitialValue;

        for (int i = 0; i < matrixSize; i++)
        {
            for (int j = 0; j < matrixSize; j++)
            {
                collectibleList.Add(Instantiate<GameObject>(collectibleToSpawn, new Vector3(spawnPosX, collectibleHeight, spawnPosZ), Quaternion.identity, groundList[(matrixSize * i) + j].transform));
                collectibleList[(matrixSize * i) + j].name = $"Collectible_{(matrixSize * i) + j}";
                collectibleList[(matrixSize * i) + j].SetActive(false);

                spawnPosX += posXIncrementValue;
            }
            spawnPosX = posXInitialValue;
            spawnPosZ -= posZIncrementValue;
        }
        spawnPosZ = posZInitialValue;
    }
    #endregion
    #region CLEAR POOL
    private void ClearGroundPool()
    {
        foreach (GameObject ground in groundList)
        {
            if (Application.isEditor) DestroyImmediate(ground);
            else Destroy(ground);
        }

        groundList.Clear();
    }

    private void ClearCollectiblePool()
    {
        foreach (GameObject collectible in  collectibleList)
        {
            if (Application.isEditor) DestroyImmediate(collectible);
            else Destroy(collectible);
        }

        collectibleList.Clear();
    }
    #endregion
    public void CreatePool()
    {
        GenerateGroundPool();
        GenerateCollectiblePool();
    }

    public void ClearPool()
    {
        ClearGroundPool();
        ClearCollectiblePool();
    }

    [ContextMenu("Load Map Data")]
    public void LoadMapData()
    {
        mapDataSO = Resources.Load<MapDataSO>($"ScriptableObject/MapData/MapData_{currentLevel}");
    }
}
