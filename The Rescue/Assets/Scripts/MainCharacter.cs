using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacter : MonoBehaviour
{
    private CharacterController _controller;
    private Animator _animator;
    
    Vector3 lookPos;
      
    
    [SerializeField]
    private float _speed = 3.5f;
    private float _gravity = -9.81f;
    //Vector3 newposition = new Vector3(0,0.029f,0);
    bool isTouchingGround;
    
    void Start()
    {

        _controller = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();

         


    }

    
    void Update()
    {

        CalculatedMovement();

        MoveCameraSytem();
        
    }

    public void CalculatedMovement()
    {

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
       
        
        Vector3 direction = new Vector3(horizontalInput, 0 ,verticalInput);

      

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
          
    if(_controller.isGrounded)
    {
       
        RegularMovingAnimation();
        RunningAnimations();
        JumpAnimation();
        PointAnimation();
    }
    else if(!_controller.isGrounded)
    {
        _animator.SetBool("isJumping",false);
        _animator.SetBool("isMoving",false);
        _animator.SetBool("isMovingRight",false);
        _animator.SetBool("isMovingLeft",false);
        _animator.SetBool("isMovingBack",false);
        _animator.SetBool("isRunningFoward",false);
        _animator.SetBool("isRunningRight",false);
        _animator.SetBool("isRunningLeft",false);
        _animator.SetBool("isFalling",true);
       
        
        StartCoroutine(FallTime());
        _animator.SetBool("isFallingToIdle",false); 
    }

        
    }

//ground collision detect
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
          if(Input.GetKey(KeyCode.Space))
        {
          _animator.SetBool("isJumping",true);
                   
        }
        else
        { 
            
            _animator.SetBool("isJumping",false);
        }
    }

    void PointAnimation()
    {
        
        if(Input.GetKey(KeyCode.Mouse0))
        {
           _animator.SetBool("isPoint",true);
        }
        else
        {
            _animator.SetBool("isPoint",false);
        }
    }

    void MoveCameraSytem()
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


 



IEnumerator FallTime()
  {
    yield return new WaitForSeconds(7.0f);
    _animator.SetBool("isFreeFall",true);
  }























}
