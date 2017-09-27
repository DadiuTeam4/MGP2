//Author: You Wu
//Contributor:
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Faucet : Interactable
{
    private Renderer render;

    void Start()
    {
        
        render = GetComponent<Renderer>();
    }

    void Update()
    {
        if(timeHeld > 2)
        {
            changeColor();
            EventManager.TriggerEvent(EventName.FaucetRunning);
            //Fire a event here
        }
    }
    
    private void changeColor()
    {
        render.material.color = Color.green;
        enabled = false;
    }


}
