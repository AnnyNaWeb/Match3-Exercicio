using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Face : MonoBehaviour
{
    static Face eSelected = null;
    static Color eColor = new Color(.3f, .2f, .2f, 1.0f);
    private SpriteRenderer sRender;
    private bool selecionado = false;
    private Vector2[] nextDir = new Vector2[] {Vector2.up, Vector2.left, Vector2.right};
   
    void Awake()
    {
        sRender = GetComponent<SpriteRenderer>();
    }

   
    private void Selecionado()
    {
      selecionado = true;
      soundManager.PlaySound("Select");
      sRender.color = eColor;
      eSelected = gameObject.GetComponent<Face>();


    }

    void SoltouSelecao(){
        selecionado = false;
        sRender.color = Color.white;
        eSelected = null;
       
    }

    public void TrocaSprite(SpriteRenderer sRender2){
        if(sRender.sprite == sRender2.sprite){
            return;
        }

        Sprite auxSprite = sRender2.sprite;
        sRender2.sprite = sRender.sprite;
        sRender.sprite = auxSprite;
        soundManager.PlaySound("Swap");
    }

    void OnMouseDown(){
    //verifique se é o momento de selecionar blocos
        if(sRender.sprite == null || GradeManager.instance.Mudando){
            return;
        }

//quem está selecionado
        if(selecionado){
            SoltouSelecao();
        } else{
            if(eSelected == null){
                Selecionado();
            } else{
                TrocaSprite(eSelected.sRender);
                eSelected.SoltouSelecao();
            }

        }
      
    }
}
