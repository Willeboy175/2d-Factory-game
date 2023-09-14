using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapGenerator : MonoBehaviour
{
    public int mapWidth;
    public int mapHeight;
    public bool empty;
    public bool update;
    public int[,] map;
    public float scale;
    public float threshold;
    int width;
    int height;

    public Transform offset;
    public Tilemap tilemap;
    public TileBase tile;

    // Start is called before the first frame update
    void Start()
    {
        offset.Translate(new Vector2(mapWidth/-2,mapHeight/-2));

        width = mapWidth + 1;
        height = mapHeight + 1;

        map = GenerateArray(width, height, empty);
        map = PerlinNoise(map, threshold, scale);
        RenderMap(map, tilemap, tile);
    }

    // Update is called once per frame
    void Update()
    {
        if (update)
        {
            map = PerlinNoise(map, threshold, scale);
            RenderMap(map, tilemap, tile);
            update = false;
        }
    }

    public int[,] GenerateArray(int width, int height, bool empty)
    {
        int[,] map = new int[width, height];
        for (int x = 0; x < map.GetUpperBound(0); x++)
        {
            for (int y = 0; y < map.GetUpperBound(1); y++)
            {
                if (empty)
                {
                    map[x, y] = 0;
                }
                else
                {
                    map[x, y] = 1;
                }
            }
        }
        return map;
    }

    public void RenderMap(int[,] map, Tilemap tilemap, TileBase tile)
    {
        //Clear the map (ensures we dont overlap)
        tilemap.ClearAllTiles();
        //Loop through the width of the map
        for (int x = 0; x < map.GetUpperBound(0); x++)
        {
            //Loop through the height of the map
            for (int y = 0; y < map.GetUpperBound(1); y++)
            {
                // 1 = tile, 0 = no tile
                if (map[x, y] == 1)
                {
                    tilemap.SetTile(new Vector3Int(x, y, 0), tile);
                }
            }
        }
    }

    public void UpdateMap(int[,] map, Tilemap tilemap) //Takes in our map and tilemap, setting null tiles where needed
    {
        for (int x = 0; x < map.GetUpperBound(0); x++)
        {
            for (int y = 0; y < map.GetUpperBound(1); y++)
            {
                //We are only going to update the map, rather than rendering again
                //This is because it uses less resources to update tiles to null
                //As opposed to re-drawing every single tile (and collision data)
                if (map[x, y] == 0)
                {
                    tilemap.SetTile(new Vector3Int(x, y, 0), null);
                }
            }
        }
    }

    public int[,] PerlinNoise(int[,] map, float threshold, float scale)
    {
        int y = 0;

        while (y < map.GetUpperBound(1))
        {
            int x = 0;
            while (x < map.GetUpperBound(0))
            {
                float xCoord = x / map.GetUpperBound(0) * scale;
                float yCoord = y / map.GetUpperBound(1) * scale;
                float sample = Mathf.PerlinNoise(xCoord, yCoord);
                if (sample > threshold)
                {
                    map[x, y] = 1;
                }
                else
                {
                    map[x,y] = 0;
                }
                x++;
            }
            y++;
        }
        return map;
    }


}
