using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapDataLoader : MonoBehaviour
{
    [Header("SPAWN OBJECT")]
    public GameObject groundToSpawn;
    public GameObject collectibleToSpawn;

    [Space]
    [Header("SPAWN POSITION")]
    [SerializeField] private float spawnStartPosX = 0.5f;
    [SerializeField] private float spawnStartPosZ = 0.5f;
    [SerializeField] private float collectibleHeight;

    [Space]
    [Header("GAME OBJECT LIST")]
    [SerializeField] private int matrixSize;
    public List<GameObject> groundList = new List<GameObject>();
    public List<GameObject> collectibleList = new List<GameObject>();

    [Header("MAP DATA")]
    public MapDataSO mapDataSO;
    public int currentLevel;
 
    private void Awake()
    {
        GenerateObjectPool();
    }

    #region Create Pool
    private void GenerateObjectPool()
    {
        for (int i = 0; i < matrixSize; i++)
        {
            for (int j = 0; j < matrixSize; j++)
            {
                groundList.Add(Instantiate<GameObject>(groundToSpawn, new Vector3(spawnStartPosX, 0, spawnStartPosZ), Quaternion.identity, transform));
                groundList[(matrixSize * i) + j].name = $"Ground_{(matrixSize * i) + j}";
                groundList[(matrixSize * i) + j].SetActive(false);
                
                collectibleList.Add(Instantiate<GameObject>(collectibleToSpawn, new Vector3(spawnStartPosX, collectibleHeight, spawnStartPosZ), Quaternion.identity, groundList[(matrixSize * i) + j].transform));
                collectibleList[(matrixSize * i) + j].name = $"Collectible_{(matrixSize * i) + j}";
                collectibleList[(matrixSize * i) + j].SetActive(false);
                
                spawnStartPosX += 1;
            }
            spawnStartPosX = 0.5f;
            spawnStartPosZ -= 1;
        } 
    }   
    #endregion
    [ContextMenu("Load Map Data")]
    public void CurrentMapData()
    {
        mapDataSO = Resources.Load<MapDataSO>($"ScriptableObject/MapData/MapData_{currentLevel}");
    }
}
