using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy1 : MonoBehaviour
{

    private float _gravity = 1f;
    private float _temporaryVelocityY;
    private float _speed = 2f;
    private float Life = 2.0f;
    public static bool _mainCharacterHitted;
    bool enemyisDead;
   
    
   // public static bool _mainCharacterHitStatus;

  
    
    private MainCharacter _mainCharacter;
    private CharacterController _controller;
    [SerializeField] private Transform movePositionTransform;
    [SerializeField] private Transform ragdollPrefab;
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
        _mainCharacter = GetComponent<MainCharacter>();
       
       
      
    }

    
    void Update()
    {
       NavMeshEnemy();
       AnimationIdle();
    }

    

    void NavMeshEnemy()
    {
       _navMeshAgent.destination = movePositionTransform.position;
    }

    void AnimationIdle()
    {
        if(MainCharacter.MainCharacterIsDead == true)
        {
            Debug.Log("is dead");
            _animator.SetBool("isPunching",false);
            _animator.SetBool("EnemyIdle",true);
            _navMeshAgent.speed = 0f;

        }
    }

    void EnemyDead()
    {
       if(Life <= 0)
       {
        if(ragdollPrefab != null)
        {
            Instantiate(ragdollPrefab,transform.position,transform.rotation);
        }
        this.gameObject.SetActive(false);
       }
    }


    private void OnTriggerEnter(Collider other) 
    {

        if(other.gameObject.tag == "MainCharacter")
        {
            _animator.SetBool("isPunching",true);
            _colider.isTrigger = false;
            _mainCharacterHitted = true;
            _navMeshAgent.speed = 0f;
        }
         
   


        if(other.gameObject.tag == "InteractiveObjects")
        {
            _colider.isTrigger = false;
            _animator.SetBool("isEnemyHitted",true);
            Life -= 0.1f;
        }
        
        
    }
    private void OnTriggerExit(Collider other) 
    {
        if(other.gameObject.tag == "MainCharacter")
        {
       

          
            _colider.isTrigger = true;
            _animator.SetBool("isPunching",false);
            _mainCharacterHitted = false;
            _navMeshAgent.speed = 4.0f;
             
            
        }

         if(other.gameObject.tag == "InteractiveObjects")
        {
             _colider.isTrigger = true;
            _animator.SetBool("isEnemyHitted",false);
            EnemyDead();
        }


    }

    IEnumerator HitTimeOut()
    {
        _navMeshAgent.speed = 0f;
        
        yield return new WaitForSeconds(0.9f);
        Debug.Log("time");
        
    }

    
 }
