using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableItem : MonoBehaviour
{

    public GameObject[] CollectableItems;
    
    public GameObject obj0;
    public GameObject obj1;
    public GameObject obj2;
    public GameObject obj3;
    public GameObject obj4;
    
    public bool CanRotate;
    
    

    void Start()
    {
       CanRotate = false;
    }

    
    void Update()
    {
        CollectableItems = new GameObject[5]{obj0,obj1,obj2,obj3,obj4};
    }


    private void OnTriggerStay(Collider other) 
    {
      if(other.gameObject.name == "Collectable0")
        {
         
          if(Input.GetKey(KeyCode.E))
         {
           obj0 = GameObject.Find("Collectable0");
           obj0.SetActive(false);
         }
      
        }   
      
        if(other.gameObject.name == "Collectable1")
        {
          if(Input.GetKey(KeyCode.E))
         {
           obj1 = GameObject.Find("Collectable1");
           obj1.SetActive(false);
         }  
   
        }

        if(other.gameObject.name == "Collectable2")
        {
          if(Input.GetKey(KeyCode.E))
          {
           obj2 = GameObject.Find("Collectable2");
           obj2.SetActive(false);
          }  
        }

        if(other.gameObject.name == "Collectable3")
        {
          if(Input.GetKey(KeyCode.E))
          {
           obj3 = GameObject.Find("Collectable3");
           obj3.SetActive(false);
          }
        }

        if(other.gameObject.name == "Collectable4")
        {
         if(Input.GetKey(KeyCode.E))
         {
         obj4 = GameObject.Find("Collectable4");
         obj4.SetActive(false);
         }
        }
    }
}
