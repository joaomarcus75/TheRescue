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

    void Start()
    {
       
    }

    
    void Update()
    {
        CollectableItems = new GameObject[5]{obj0,obj1,obj2,obj3,obj4};
    }

    private void OnTriggerEnter(Collider other)
    {
         
        if(other.gameObject.name == "Collectable0")
        {
            //Debug.Log("testing");
         obj0 = GameObject.Find("Collectable0");
        
        }
        if(other.gameObject.name == "Collectable1")
        {
            //Debug.Log("testing");
         obj0 = GameObject.Find("Collectable1");
        
        }
        if(other.gameObject.name == "Collectable2")
        {
            //Debug.Log("testing");
         obj0 = GameObject.Find("Collectable2");
        
        }
        if(other.gameObject.name == "Collectable3")
        {
            //Debug.Log("testing");
         obj0 = GameObject.Find("Collectable3");
        
        }
        if(other.gameObject.name == "Collectable4")
        {
            //Debug.Log("testing");
         obj0 = GameObject.Find("Collectable4");
        
        }

    }
}
