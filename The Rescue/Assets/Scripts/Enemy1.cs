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
    Vector3 direction;
    Vector3 velocity;
    
    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        
    }
    void Start()
    {
       _controller = GetComponent<CharacterController>(); 
    }

    
    void Update()
    {
    //     velocity = direction * _speed;
    //    _temporaryVelocityY -= _gravity;
    //     velocity.y = _temporaryVelocityY;
    //    velocity = transform.transform.TransformDirection( velocity);
       
    //    _controller.Move(velocity * Time.deltaTime);
      

       _navMeshAgent.destination = movePositionTransform.position;
    }
}
