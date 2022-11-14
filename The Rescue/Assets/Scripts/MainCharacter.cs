using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacter : MonoBehaviour
{
    private CharacterController _controller;
    private Animator _animator;
    //
    Vector3 lookPos;
      
    
    [SerializeField] private float _speed = 2f;
    [SerializeField]private float _gravity = 1f;
   
    [SerializeField]private float jumpspeed = 5f;
    public float _temporaryVelocityY;

    bool isTouchingGround;

    Vector3 direction;
    Vector3 velocity;
    float horizontalInput;
    float verticalInput;
    
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        CalculatedMovement();

        CharacterRotation();

    }

    public void CalculatedMovement()
    {
        
        MovementationCombined();
        AnimationsMovement();
    }

    public void AnimationsMovement()
    {
          if(_controller.isGrounded)
       {
         RegularMovingAnimation();
         RunningAnimations();
         JumpAnimation();
       }
    }



void OnControllerColliderHit(ControllerColliderHit hit) 
  {

    if(hit.gameObject.tag == "Ground")
    {
        //Debug.Log("Is Grounded"); 
        _animator.SetBool("isFalling",false);
        _animator.SetBool("isFallingToIdle",true);
    }

  } 

  void RegularMovingAnimation()
  {
     if(Input.GetKey(KeyCode.W))
        {
            _animator.SetBool("isMoving",true);

            if(Input.GetKey(KeyCode.D))
            {
              
              _animator.SetBool("isMoving",false);
              _animator.SetBool("isMovingRight",true);
              
            }
            if(Input.GetKey(KeyCode.A))
            {
              
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
              
              _animator.SetBool("isMovingBack",false);
              _animator.SetBool("isMovingRight",true);
              
            }
            if(Input.GetKey(KeyCode.A))
            {
              
              _animator.SetBool("isMovingBack",false);
              _animator.SetBool("isMovingLeft",true);
            }
        }
        else
        {
            _animator.SetBool("isMovingBack",false);
        }
  }

  void RunningAnimations()
  {
        //Running Foward and Backward
        if(Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
        {
            _animator.SetBool("isRunningFoward",true);
        }
        else
        {
            _animator.SetBool("isRunningFoward",false);
        }

         if(Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.S))
        {
            _animator.SetBool("isRuningBackward",true);
            if( Input.GetKey(KeyCode.D))
            {
                _animator.SetBool("isRuningBackward",false);
                _animator.SetBool("isRunningRight",true);
            }
            if( Input.GetKey(KeyCode.A))
            {
                _animator.SetBool("isRuningBackward",false);
                _animator.SetBool("isRunningLeft",true);
            }
        }
         else
        {
            _animator.SetBool("isRuningBackward",false);
        }

       //////Running right side
        if(Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.D))
        {
            
            _animator.SetBool("isRunningRight",true);
            
            if(Input.GetKey(KeyCode.W))
            {
                
                _animator.SetBool("isRunningRight",false);
                _animator.SetBool("isMovingRight",false);
                _animator.SetBool("isMoving",true);
                _animator.SetBool("isRunningFoward",true);
            }
        }
        else
        {
            _animator.SetBool("isRunningRight",false);
        }
        if(Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.A))
        {
            _animator.SetBool("isRunningLeft",true);

            if(Input.GetKey(KeyCode.W))
            {
                
                _animator.SetBool("isRunningLeft",false);
                _animator.SetBool("isMovingLeft",false);
                _animator.SetBool("isMoving",true);
                _animator.SetBool("isRunningFoward",true);
            }
        }
        else
        {
            _animator.SetBool("isRunningLeft",false);
        }
  } 
    void JumpAnimation()
    {
          if(Input.GetKeyDown(KeyCode.Space))
        {
          _animator.SetBool("isRunToJumping",true);
                   
        }
        else
        { 
            
            _animator.SetBool("isRunToJumping",false);
        }
        
    }

  

    

    void CharacterRotation()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray,out hit,100))
        {
           lookPos = hit.point;
        }

        Vector3 lookDirection = lookPos - transform.position;
        lookDirection.y = 0;

        transform.LookAt(transform.position + lookDirection,Vector3.up);
    }

    void MovementationCombined()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
       
        
        direction = new Vector3(horizontalInput, 0 ,verticalInput);

      

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
            if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D) )
            {
              direction = new Vector3(0,0,verticalInput);


            }
            if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A) )
            {
              direction = new Vector3(0,0,verticalInput);

            }
        }
        else
        {
            _speed = 2f;    
        }

               
        velocity = direction * _speed;
             
        _temporaryVelocityY -= _gravity;

        velocity.y = _temporaryVelocityY;

        velocity = transform.transform.TransformDirection(velocity);


       
        Jump();
     
        _controller.Move(velocity * Time.deltaTime);
    }

    void Jump()
    {
        if(Input.GetButtonDown("Jump") && _controller.isGrounded)
        {
          _temporaryVelocityY = jumpspeed;
          
        }
       
    }

IEnumerator jumpTime()
{
    _gravity -= 1;
    yield return new WaitForSeconds(0.5f);
    _gravity -= -1;

}
 



























}
