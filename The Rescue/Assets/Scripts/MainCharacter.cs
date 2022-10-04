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

        if(Input.GetKey(KeyCode.W))
        {
            direction = new Vector3(0,0,verticalInput);
        }

        if(Input.GetKey(KeyCode.S))
        {
            direction = new Vector3(0,0,verticalInput);
        }
        if(Input.GetKey(KeyCode.A)) 
        {
            direction = new Vector3(horizontalInput,0,0);
        }
        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W)) 
        {
            direction = new Vector3(horizontalInput,0,0);
        } 
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W)) 
        {
            direction = new Vector3(horizontalInput,0,0);
        } 
        if(Input.GetKey(KeyCode.LeftShift))
        {
            _speed = 6f;
        }
        else
        {
            _speed = 3.5f;
        }
        

        


        
        Vector3 velocity = direction * _speed;
             
        velocity.y = _gravity;
        velocity = transform.transform.TransformDirection(velocity);

        
     
        _controller.Move(velocity * Time.deltaTime);
        
        AnimationsMovement();

    
    }

    public void AnimationsMovement()
    {
        if(Input.GetKey(KeyCode.W))
        {
            _animator.SetBool("isMoving",true);

            if(Input.GetKey(KeyCode.D))
            {
              //Debug.Log("W+D");
              _animator.SetBool("isMoving",false);
              _animator.SetBool("isMovingRight",true);
              
            }
            if(Input.GetKey(KeyCode.A))
            {
              //Debug.Log("W+A");
              _animator.SetBool("isMoving",false);
              _animator.SetBool("isMovingLeft",true);
            }
          
            
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



        if(Input.GetKey(KeyCode.S))
        {
            _animator.SetBool("isMovingBack",true);

             if(Input.GetKey(KeyCode.D))
            {
              //Debug.Log("S+D");
              _animator.SetBool("isMovingBack",false);
              _animator.SetBool("isMovingRight",true);
              
            }
            if(Input.GetKey(KeyCode.A))
            {
              //Debug.Log("S+A");
              _animator.SetBool("isMovingBack",false);
              _animator.SetBool("isMovingLeft",true);
            }
        }
        else
        {
            _animator.SetBool("isMovingBack",false);
        }
        


        //Running in place bug fix
        if(Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
        {
            _animator.SetBool("isRunningFoward",true);
        }
        else
        {
            _animator.SetBool("isRunningFoward",false);
        }

        //Running right side
        if(Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.D))
        {
            _animator.SetBool("isRunningRight",true);
        }
        else
        {
            _animator.SetBool("isRunningRight",false);
        }
        if(Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.A))
        {
            _animator.SetBool("isRunningLeft",true);
        }
        else
        {
            _animator.SetBool("isRunningLeft",false);
        }

        

        
        


    }


}