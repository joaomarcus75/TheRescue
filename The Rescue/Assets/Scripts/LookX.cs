using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookX : MonoBehaviour
{
    private float _sensitivity = 1f;
    void Start()
    {
        
    }

    
    void Update()
    {
        
        float _mouseX = Input.GetAxis("Mouse X");
        

        Vector3 newRotation = transform.eulerAngles;
        newRotation.y += _mouseX * _sensitivity;
        transform.localEulerAngles = newRotation;
        //Debug.Log("mouse =  " + newRotation.y);

       

    }
}
