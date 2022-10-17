using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Transform Hand;
    MainCharacter mainCharacter;
    private Animator _animator;

    
    void OnMouseDown() 
    {
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().freezeRotation = true;
        this.transform.position = Hand.position;
        this.transform.parent = GameObject.Find("Hand").transform;
    }
    void OnMouseUp() 
    {
       GetComponent<BoxCollider>().enabled = true;
       GetComponent<Rigidbody>().AddForce(this.transform.parent.forward * 500f);
       this.transform.parent = null;
       GetComponent<Rigidbody>().useGravity = true;
       GetComponent<Rigidbody>().freezeRotation = false;
    }

    



}
