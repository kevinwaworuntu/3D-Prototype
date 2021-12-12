using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapDataLoader : MonoBehaviour
{
    [Header("SPAWN OBJECT")]
    public GameObject objectToSpawn;
    public GameObject collectiblePrefabs;

    [Space]
    [Header("SPAWN POSITION")]
    public Transform[] spawnPosition;
    [SerializeField] private float collectibleHeight;

    [Space]
    [Header("GAME OBJECT LIST")]
    public List<GameObject> listObject = new List<GameObject>();
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
        for (int i = 0; i < spawnPosition.Length; i++)
        {
            listObject.Add(Instantiate(objectToSpawn, spawnPosition[i]));
            listObject[i].SetActive(false);
            collectibleList.Add(Instantiate(collectiblePrefabs, spawnPosition[i]));
            collectibleList[i].transform.position = new Vector3(spawnPosition[i].position.x, spawnPosition[i].position.y + collectibleHeight, spawnPosition[i].position.z);
            collectibleList[i].SetActive(false);
        }
    }
    #endregion
    [ContextMenu("Load Map Data")]
    public void CurrentMapData()
    {
        mapDataSO = Resources.Load<MapDataSO>($"ScriptableObject/MapData/MapData_{currentLevel}");
    }
}
