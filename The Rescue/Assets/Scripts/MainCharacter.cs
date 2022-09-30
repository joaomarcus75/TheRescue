using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacter : MonoBehaviour
{
    private CharacterController _controller;
    private Animator _animator;
    
    [SerializeField]
    private float _speed = 3.5f;
    private float _gravity = -9.81f;
    
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        CalculatedMovement();
        
    }

    

    public void CalculatedMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        
        Vector3  direction = new Vector3(horizontalInput, 0 ,verticalInput);

        if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W) )
        {
            direction = new Vector3(0,0,verticalInput);
             
        }
        

        if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            direction = new Vector3(0,0,verticalInput);
        }
        
        Vector3 velocity = direction * _speed;
             
        velocity.y = _gravity;
        velocity = transform.transform.TransformDirection(velocity);

        
     
        _controller.Move(velocity * Time.deltaTime);
        
        AnimationsMovement();


        // if(direction != Vector3.zero)
        // {
        //     _animator.SetBool("isMoving",true);
        // }
        // else
        // {
        //     _animator.SetBool("isMoving",false);
        // }

      



    
    }

    public void AnimationsMovement()
    {
        if(Input.GetKey(KeyCode.W))
        {
            _animator.SetBool("isMoving",true);
        }
        else
        {
           _animator.SetBool("isMoving",false);
        }


        if (Input.GetKey(KeyCode.D))
        {
            _animator.SetBool("isMovingRight",true);
        }
        else
        {
            _animator.SetBool("isMovingRight",false);
        }

        if(Input.GetKey(KeyCode.A))
        {
             _animator.SetBool("isMovingLeft",true);
        }
        else
        {
            _animator.SetBool("isMovingLeft",false);
        }

        
        


    }


}
