using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Windows;

public class PerlinNoiseMap : MonoBehaviour
{
    Dictionary<int, GameObject> tileset;
    Dictionary<int, GameObject> tileGroups;
    public GameObject prefabWater;
    public GameObject PrefabGrass;
    public GameObject PrefabStone;
    public GameObject PrefabOre;

    int mapWidth = 128;
    int mapHeight = 128;

    List<List<int>> noiseGrid = new List<List<int>>();
    List<List<GameObject>> tileGrid = new List<List<GameObject>>();

    //recommend 4 to 20
    float magnification = 7.0f;

    int xOffset = 0; // <- +>
    int yOffset = 0; // v- +^

    // Start is called before the first frame update
    void Start()
    {
        CreateTileset();
        CreateTileGroups();
        GenerateMap();
    }

    void CreateTileset()
    {
        //Collect and assign ID codes to the tile prefabs
        //for ease of use best ordered to match land elevation

        tileset = new Dictionary<int, GameObject>();
        tileset.Add(0, prefabWater);
        tileset.Add(1, PrefabGrass);
        tileset.Add(2, PrefabStone);
        tileset.Add(3, PrefabOre);
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

        //Replaced 4 with tileset
        //Count to make adding tiles easier
        if (scaledPerlin == 4)
        {
            scaledPerlin = 3;
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
