using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy1 : MonoBehaviour
{

    private float _gravity = 1f;
    private float _temporaryVelocityY;
    private float _speed = 2f;
    public static bool _mainCharacterHitted;
   // public static bool _mainCharacterHitStatus;

  
    
    
    private CharacterController _controller;
    [SerializeField] private Transform movePositionTransform;
    private NavMeshAgent _navMeshAgent;
    private Animator _animator;
    
    
    private Collider _colider;
    Vector3 direction;
    Vector3 velocity;
    
    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
       
        
    }
    void Start()
    {
       
       _controller = GetComponent<CharacterController>(); 
       _animator = GetComponent<Animator>();
       _colider = GetComponent<Collider>();
      
    }

    
    void Update()
    {
       NavMeshEnemy();
       
    }

    void NavMeshEnemy()
    {
       _navMeshAgent.destination = movePositionTransform.position;
    }


    private void OnTriggerEnter(Collider other) 
    {

        if(other.gameObject.tag == "MainCharacter")
        {
            _animator.SetBool("isPunching",true);
            _colider.isTrigger = false;
            _mainCharacterHitted = true;
            _navMeshAgent.speed = 0f;
           //USE RAGDOLL SYSTEM TO MAKE OUR MAIN CHARACTER BE HITTED
            //Debug.Log(_mainCharacterHitted);
        }
        
        
    }
    private void OnTriggerExit(Collider other) 
    {
        if(other.gameObject.tag == "MainCharacter")
        {
            _animator.SetBool("isPunching",false);
            _colider.isTrigger = true;
            _mainCharacterHitted = false;
            _navMeshAgent.speed = 4.0f;
           // Debug.Log(_mainCharacterHitted);
        }
        
    }

    IEnumerator HitTimeOut()
    {
        _navMeshAgent.speed = 0f;
        
        yield return new WaitForSeconds(0.9f);
        Debug.Log("time");
        
    }

 }
