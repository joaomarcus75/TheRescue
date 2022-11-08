using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    private float _gravity = 1f;
    private float _temporaryVelocityY;
    private float _speed = 2f;
    
    private CharacterController _controller;
    Vector3 direction;
    Vector3 velocity;
    
    
    void Start()
    {
       _controller = GetComponent<CharacterController>(); 
    }

    
    void Update()
    {
        velocity = direction * _speed;
       _temporaryVelocityY -= _gravity;
        velocity.y = _temporaryVelocityY;
       velocity = transform.transform.TransformDirection( velocity);
       
       _controller.Move(velocity * Time.deltaTime);
      // direction = new Vector3(0,  1f ,0);
    }
}
