using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseClick : MonoBehaviour
{
    private static mouseClick precedMudando = null; 
    private bool dentro;
    private bool arrastando;
    private SpriteRenderer render;
    private static Color pintou = new Color(.5f, .5f, .5f, 1.0f);
    [SerializeField]private Rigidbody2D rb;
     private void Start(){
  
       render = GetComponent<SpriteRenderer>();
       
    }
   
    private void Pegou(){
     
         dentro = true;
        soundManager.PlaySound("Select");
         render.color = pintou;
         precedMudando = gameObject.GetComponent<mouseClick>();
       
    }

    private void Soltou() {
        render.color = Color.white;
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
                MudaSprite(precedMudando.render);
                precedMudando.Soltou();
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
   

   
}
