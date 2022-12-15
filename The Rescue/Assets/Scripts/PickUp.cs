using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Transform Hand;
    MainCharacter mainCharacter;
    private Animator _animator;
   
    private float slowMotionTimeScale = 0.1f;
    private float _startTimeScale;
    private float _startFixedDeltaTime;

    //private Vector3 _floatingPosition;
   
   
    void OnMouseDown() 
    {
        GetComponent<Rigidbody>().useGravity = false;
        this.transform.position = new Vector3 (this.transform.position.x, 2f, this.transform.position.z);
        this.transform.parent = GameObject.Find("Hand").transform;
        
    }
    void OnMouseUp() 
    {
       this.transform.parent = null;
       GetComponent<Rigidbody>().useGravity = true;
       
       //GetComponent<Rigidbody>().freezeRotation = false;
    }

    



}
