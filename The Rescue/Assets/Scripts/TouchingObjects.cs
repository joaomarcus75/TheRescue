using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchingObjects : MonoBehaviour
{


Rigidbody rigid;

void Start()
{
  rigid = this.gameObject.GetComponent<Rigidbody>();
}

    private void OnCollisionEnter(Collision other) 
    {
     //touching normaly

    
     if(other.gameObject.tag == "MainCharacter")
     {
         
        
        Debug.Log("Main character touch");
        rigid.AddForce(-transform.forward * 100);
        
               
     }
     
     
    }








}
