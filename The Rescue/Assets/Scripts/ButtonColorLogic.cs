using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonColorLogic : MonoBehaviour
{
    public GameObject LightGreen;
    public GameObject ButtonColorGreen;
    public GameObject LightRed;
    public GameObject ButtonColorRed;
    void Start()
    {
        

    }

    
    void Update()
    {
        

    }

    private void OnTriggerStay(Collider other) 
    {
        if(other.gameObject.tag == "MainCharacter")
        {
            Debug.Log("Button");
            if(Input.GetKey(KeyCode.E))
            {
                Debug.Log("BUTTON E PRESSED");
                //CHANGE BUTTON COLORS
                ButtonColorGreen.SetActive(true);
                ButtonColorRed.SetActive(false);
                //CHANGE LIGHT COLORS
                LightGreen.SetActive(true);
                LightRed.SetActive(false);
            }
        }

    }
}
