using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(MapDataLoader))]
public class MapGenerator : MonoBehaviour
{
    [Header("MAP DATA REFERENCE")]
    [SerializeField] private MapDataLoader mapDataLoader;

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
        EnableObjectFromSO(true);
    }

    #region Enable Object From SO
    private void EnableObjectFromSO(bool visible)
    {
        if (visible)
        {
            for (int i = 0; i < mapDataLoader.mapDataSO.mapDataContainer.Count; i++)
            {
                switch (mapDataLoader.mapDataSO.mapDataContainer[i])
                {
                    case MapStatus.none:
                        break;
                    case MapStatus.generateMap:
                        mapDataLoader.listObject[i].SetActive(true);
                        mapDataLoader.listObject[i].GetComponent<NavMeshSurface>().BuildNavMesh();
                        break;
                    case MapStatus.generateMapPlusCoin:
                        mapDataLoader.listObject[i].SetActive(true);
                        mapDataLoader.listObject[i].GetComponent<NavMeshSurface>().BuildNavMesh();
                        mapDataLoader.collectibleList[i].SetActive(true);
                        break;
                }

            }
        }
        else
        {
            for (int i = 0; i < mapDataLoader.mapDataSO.mapDataContainer.Count; i++)
            {
                mapDataLoader.listObject[i].SetActive(false);
            }
        }
    }
    #endregion
    #region Enable Object From Pool
    private void ObjectFromPoolActiveStatus(bool visible)
    {
        if (visible)
        {
            for (int i = 0; i < mapDataLoader.listObject.Count; i++)
            {
                mapDataLoader.listObject[i].SetActive(true);
            }
        }
        else
        {
            for (int i = 0; i < mapDataLoader.listObject.Count; i++)
            {
                mapDataLoader.listObject[i].SetActive(false);
                mapDataLoader.collectibleList[i].SetActive(false);
            }
        }
    }
    #endregion
}
