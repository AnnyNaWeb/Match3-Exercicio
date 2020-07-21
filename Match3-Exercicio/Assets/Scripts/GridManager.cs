using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public static GridManager instance;
    public List<Sprite> characters = new List<Sprite>();
    public GameObject tile;
    public int xSize, ySize;
    private GameObject[,] tiles;
    public bool Mudando { get; set; }
    
    void Start()
    {
        instance = GetComponent<GridManager>();

        Vector2 offset = tile.GetComponent<SpriteRenderer>().bounds.size;
        CreateGrid(offset.x, offset.y);
        
    }

    private void CreateGrid (float xOffset, float yOffset)
    {
        tiles = new GameObject[xSize, ySize];

        float startX = transform.position.x;
        float startY = transform.position.y;

        for (int x = 0; x < xSize; x++)
        {
        
               for (int y = 0; y < ySize; y++) {
                GameObject newTile = Instantiate(tile, new Vector3(startX + (xOffset * x), startY +                                                                 (yOffset * y), 0), tile.transform.rotation);
            
            }
        }
    }
}
