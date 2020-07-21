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

         Sprite[] previousLeft = new Sprite[ySize];
         Sprite previousBelow = null;
        for (int x = 0; x < xSize; x++)
        {
        
               for (int y = 0; y < ySize; y++) {
                GameObject newTile = Instantiate(tile, new Vector3(startX + (xOffset * x), startY +                                                                 (yOffset * y), 0), tile.transform.rotation);
                newTile.transform.parent = transform;

                List<Sprite> possivelCharacters = new List<Sprite>();
                possivelCharacters.AddRange(characters);

                possivelCharacters.Remove(previousLeft[y]);
                possivelCharacters.Remove(previousBelow);

                Sprite newSprite = possivelCharacters[Random.Range(0, possivelCharacters.Count)];
                newTile.GetComponent<SpriteRenderer>().sprite = newSprite;

                previousLeft[y] = newSprite;
                previousBelow = newSprite;

            }
        }

        
    }
}
