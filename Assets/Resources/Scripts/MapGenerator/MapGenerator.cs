using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(MapDataLoader))]
public class MapGenerator : MonoBehaviour
{
    [Header("MAP DATA REFERENCE")]
    [SerializeField] private MapDataLoader mapDataLoader;

    [Header("GAMEPLAY SCENE OR DESIGN SCENE")]
    [SerializeField] private bool isFromMapLoader = true;

    private void Awake()
    {
        mapDataLoader = GetComponent<MapDataLoader>();
    }

    #region View All Tiles
    [ContextMenu("View All Tiles")]
    void ViewAllTiles()
    {
        ObjectFromPoolActiveStatus(true);
    }
    #endregion

    [ContextMenu("De-Generate Map")]
    public void DegenerateMap()
    {
        ObjectFromPoolActiveStatus(false);
    }

    [ContextMenu("Generate Map")]
    public void GenerateMapFromSO()
    {
        EnableObjectFromSO(isFromMapLoader);
    }

    #region Enable Object From SO
    private void EnableObjectFromSO(bool isFromMapLoader)
    {
        if (isFromMapLoader)
        {
            for (int i = 0; i < mapDataLoader.mapDataSO.mapDataContainer.Count; i++)
            {
                switch (mapDataLoader.mapDataSO.mapDataContainer[i])
                {
                    case MapStatus.none:
                        break;
                    case MapStatus.generateMap:
                        mapDataLoader.groundList[i].SetActive(true);
                        mapDataLoader.groundList[i].GetComponent<NavMeshSurface>().BuildNavMesh();
                        break;
                    case MapStatus.generateMapPlusCoin:
                        mapDataLoader.groundList[i].SetActive(true);
                        mapDataLoader.groundList[i].GetComponent<NavMeshSurface>().BuildNavMesh();
                        mapDataLoader.collectibleList[i].SetActive(true);
                        break;
                }
            }
        }
        else
        {
            var mapMaker = GetComponent<MapMaker>();
            for (int i = 0; i < mapMaker.mapDataSO.mapDataContainer.Count; i++)
            {
                switch (mapMaker.mapDataSO.mapDataContainer[i])
                {
                    case MapStatus.none:
                        break;
                    case MapStatus.generateMap:
                        mapDataLoader.groundList[i].SetActive(true);
                        mapDataLoader.groundList[i].GetComponent<NavMeshSurface>().BuildNavMesh();
                        break;
                    case MapStatus.generateMapPlusCoin:
                        mapDataLoader.groundList[i].SetActive(true);
                        mapDataLoader.groundList[i].GetComponent<NavMeshSurface>().BuildNavMesh();
                        mapDataLoader.collectibleList[i].SetActive(true);
                        break;
                }
            }
        }
    }
    #endregion
    #region Enable Object From Pool
    private void ObjectFromPoolActiveStatus(bool visible)
    {
        if (visible)
        {
            for (int i = 0; i < mapDataLoader.groundList.Count; i++)
            {
                mapDataLoader.groundList[i].SetActive(true);
            }
        }
        else
        {
            for (int i = 0; i < mapDataLoader.groundList.Count; i++)
            {
                mapDataLoader.groundList[i].SetActive(false);
                mapDataLoader.collectibleList[i].SetActive(false);
            }
        }
    }
    #endregion
}
