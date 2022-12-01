using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleMessageTrigger : MonoBehaviour
{
    public GameObject PuzzleMessage; 
    private void OnTriggerEnter(Collider other) 
    {
      if(other.gameObject.tag == "MainCharacter")
      {
        PuzzleMessage.SetActive(true);
      }  
    }

    private void OnTriggerExit(Collider other) 
    {
       if(other.gameObject.tag == "MainCharacter")
      {
        PuzzleMessage.SetActive(false);
      }     
    }
}
