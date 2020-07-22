using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseClick : MonoBehaviour
{
    private static mouseClick precedMudando = null; 
    private bool dentro = false;
    private bool arrastando;
    private SpriteRenderer render;
    private static Color pintou = new Color(.3f, .2f, .7f, 1.0f);
    [SerializeField]private Rigidbody2D rb;
    private Vector2[] adjacentDirections = new Vector2[] {Vector2.up, Vector2.down, Vector2.left, Vector2.right};
     private void Start(){
  
       render = GetComponent<SpriteRenderer>();
       
    }
   
    private void Pegou(){
     
         
        soundManager.PlaySound("Select");
         render.color = pintou;
         precedMudando = gameObject.GetComponent<mouseClick>();
         dentro = true;
       
    }

    private void Soltou() {
       
        render.color = Color.white;
        soundManager.PlaySound("Swap");
        precedMudando = null;
        dentro = false;
        
    }

    void OnMouseDown(){
       if(render.sprite == null || GridManager.instance.Mudando){
            return;
        }
        if(dentro){
            Soltou();
        } else{
            if (precedMudando == null){
                Pegou();
            } else{
            //    if(GetAllAdjacentGrid().Contains(precedMudando.gameObject)){
               //     MudaSprite(precedMudando.render);
                //    precedMudando.Soltou();
               // }
             //  else{
               //    precedMudando.GetComponent<mouseClick>().Soltou();
               //    Pegou();
              // }
              
              //  MudaSprite(precedMudando.render);
              //  precedMudando.Soltou();
            }
        }
    }

    void MudaSprite(SpriteRenderer render2){
        if(render.sprite == render2.sprite){
            return;
        }

        Sprite auxSprite = render2.sprite;
        render2.sprite = render.sprite;
        render.sprite = auxSprite;
        soundManager.PlaySound("Swap");
    }

    private GameObject GetAdjacent(Vector2 rcDir){
        RaycastHit2D hit = Physics2D.Raycast(transform.position, rcDir);
        if(hit.collider != null){
            return hit.collider.gameObject;
        }
        return null;
    }

    private List<GameObject> GetAllAdjacentGrid(){
        List<GameObject> adjacentGrid = new List<GameObject>();
        for (int i = 0; i < adjacentDirections.Length; i++){
            adjacentGrid.Add(GetAdjacent(adjacentDirections[i]));
        }
        return adjacentGrid;
    }
   

   
}
