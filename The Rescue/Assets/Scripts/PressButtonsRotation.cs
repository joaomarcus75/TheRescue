using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressButtonsRotation : MonoBehaviour
{
  private  Vector3 _rotation = new Vector3(0f,40f,0f);
  private Quaternion _beforeRotate;
  public CollectableItem collectableItem;
   
    void Start()
    {
       _beforeRotate = this.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerStay(Collider other) 
    {
        if(other.gameObject.tag == "MainCharacter")
        {
            Debug.Log("it's entering");
           transform.Rotate(_rotation * Time.deltaTime);
        }
        
    }
    private void OnTriggerExit(Collider other) 
    {
        Debug.Log("Exit");
        this.transform.rotation = _beforeRotate;
    }
}
