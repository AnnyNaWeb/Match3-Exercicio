using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GradeManager : MonoBehaviour
{
    public static GradeManager instance;

    public List<Sprite> elementos = new List<Sprite>();
    public GameObject face;
    private GameObject[,] faces;
    public int xSize, ySize;
    public bool Movimento {get; set;}
    public bool Mudando { get; set; }

   
    void Start()
    {
        instance = GetComponent<GradeManager>();
        Vector2 offset = face.GetComponent<SpriteRenderer>().bounds.size;
        CriaGrade(offset.x, offset.y);
        
    }
    void CriaGrade(float xOffset, float yOffset){
        faces = new GameObject[xSize, ySize];
        float startX = transform.position.x;
        float startY = transform.position.y;

// previsão de sprites repetidos
        Sprite[] e_left = new Sprite[ySize];
        Sprite e_baixo = null;

        for (int x = 0; x < xSize; x++){

            for(int y = 0; y <  ySize; y++){
                GameObject newFace = Instantiate(face, new Vector3(startX + (xOffset*x), startY + (yOffset*y), 0), face.transform.rotation);
                faces[x, y] = newFace;

                //randomiza ainda mais a aleatoriedade dos elementos
                List<Sprite> pElementos = new List<Sprite>();
                pElementos.AddRange(elementos);
                pElementos.Remove(e_left[y]);
                pElementos.Remove(e_baixo);
                //seleciona novo elemento da possível(p) lista e armazena
                newFace.transform.parent = transform;
                Sprite newSprite = pElementos[Random.Range(0, pElementos.Count)];
                newFace.GetComponent<SpriteRenderer>().sprite = newSprite;
                
                e_left[y] = newSprite;
                e_baixo = newSprite;
            }

        }
    }
      void Update()
    {
        
    }
}
