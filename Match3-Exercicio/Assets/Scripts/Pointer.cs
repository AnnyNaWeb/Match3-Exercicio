using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
   private float _rotationSpeed = 20f;
   private Vector3 _horizontalMovement;
    void Start()
    {
        
    }

   
    void Update()
    {
        _horizontalMovement = new Vector3(0f, 0f, -Input.GetAxis("Horizontal"));

        transform.Rotate(_horizontalMovement * _rotationSpeed * Time.deltaTime);

        if(Input.GetKey(KeyCode.Space)){
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.up)*10, Color.red);
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.up),10);

            if(hit){
                Debug.Log("Hit Something: " + hit.collider.name);
                hit.transform.GetComponent<SpriteRenderer>().color = Color.red;
            }
        }
    }
}
