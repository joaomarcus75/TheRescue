using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy1 : MonoBehaviour
{

    private float _gravity = 1f;
    private float _temporaryVelocityY;
    private float _speed = 2f;
    
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


    private void OnTriggerStay(Collider other) 
    {
        if(other.gameObject.tag == "MainCharacter")
        {
            Debug.Log("hit");
            _navMeshAgent.speed = 0;
            _animator.SetBool("isPunching",true);
            _colider.isTrigger = false;
            
        }
        
        
    }
    private void OnTriggerExit(Collider other) 
    {
        if(other.gameObject.tag == "MainCharacter")
        {
            Debug.Log("out hit");
            _navMeshAgent.speed = 3.0f;
            _animator.SetBool("isPunching",false);
            _colider.isTrigger = true;
            
        }
        
    }

 }
