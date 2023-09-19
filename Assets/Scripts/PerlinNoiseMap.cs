using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinNoiseMap : MonoBehaviour
{
    public GameObject playerSpawner;

    Dictionary<int, GameObject> tileset;
    Dictionary<int, GameObject> tileGroups;
    public GameObject prefab1;
    public GameObject prefab2;
    public GameObject prefab3;
    public GameObject prefab4;
    public GameObject prefab5;
    public GameObject prefab6;
    public GameObject prefab7;
    public GameObject prefab8;

    int mapWidth = 128;
    int mapHeight = 128;

    List<List<int>> noiseGrid = new List<List<int>>();
    List<List<GameObject>> tileGrid = new List<List<GameObject>>();

    //recommend 6 to 12
    public float magnification = 7.0f;
    public bool randomGeneration = true;

    int xOffset = 0; // <- +>
    int yOffset = 0; // v- +^

    // Start is called before the first frame update
    void Start()
    {
        if (StartMenuScript.random == true)
        {
            magnification = Random.Range(6.0f, 12.0f);
        }
        else
        {
            magnification = StartMenuScript.seed;
        }

        //Remember to remove this later
        magnification = 7.0f;
        
        CreateTileset();
        CreateTileGroups();
        GenerateMap();

        playerSpawner.SetActive(true);
    }

    void CreateTileset()
    {
        //Collect and assign ID codes to the tile prefabs
        //for ease of use best ordered to match land elevation

        tileset = new Dictionary<int, GameObject>();
        tileset.Add(0, prefab1);
        tileset.Add(1, prefab2);
        tileset.Add(2, prefab3);
        tileset.Add(3, prefab4);
        tileset.Add(4, prefab5);
        tileset.Add(5, prefab6);
        tileset.Add(6, prefab7);
        tileset.Add(7, prefab8);
        
    }

    void CreateTileGroups()
    {
        //Create empty gameobjects for grouping tile of the same type

        tileGroups = new Dictionary<int, GameObject>();
        foreach (KeyValuePair<int, GameObject> prefabPair in tileset)
        {
            GameObject tileGroup = new GameObject(prefabPair.Value.name);
            tileGroup.transform.parent = gameObject.transform;
            tileGroup.transform.localPosition = new Vector3(0, 0, 0);
            tileGroups.Add(prefabPair.Key, tileGroup);
        }
    }

    void GenerateMap()
    {
        //Generate a 2D grid using the Perlin noise function
        //storing it as both raw ID values and tile gameobject

        for (int x = 0; x < mapWidth; x++)
        {
            noiseGrid.Add(new List<int>());
            tileGrid.Add(new List<GameObject>());

            for (int y = 0; y < mapHeight; y++)
            {
                int tileId = GetIdUsingPerlin(x, y);
                noiseGrid[x].Add(tileId);
                CreateTile(tileId, x, y);
            }
        }
    }

    int GetIdUsingPerlin(int x, int y)
    {
        //Using a grid coordinate input, generate a Perlin noise value to be converted into a tile ID code
        //Rescale the normalised Perlin value to the number of tiles available

        float rawPerlin = Mathf.PerlinNoise(
            (x - xOffset) / magnification,
            (y - yOffset) / magnification
            );
        float clampPerlin = Mathf.Clamp01(rawPerlin);
        float scaledPerlin = clampPerlin * tileset.Count;

        if (scaledPerlin == tileset.Count)
        {
            scaledPerlin = (tileset.Count - 1);
        }
        return Mathf.FloorToInt(scaledPerlin);
    }

    void CreateTile(int tileId, int x, int y)
    {
        //Creates a new tile using the type id code
        //group it with common tiles
        //set it's position and store the gameobject

        GameObject tilePrefab = tileset[tileId];
        GameObject tileGroup = tileGroups[tileId];
        GameObject tile = Instantiate(tilePrefab, tileGroup.transform);

        tile.name = string.Format("tile_x{0}_y{1}", x, y);
        tile.transform.localPosition = new Vector3(x, y, 0);

        tileGrid[x].Add(tile);
    }
}
