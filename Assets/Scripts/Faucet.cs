//Author: You Wu
//Contributor: Kristian 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Faucet : NumberFoundInteractable
{

    void Start()
    {
        base.Start();
    }

    void Update()
    {
        if(timeHeld > fireAfterSeconds)
        {
            changeColor();
            EventManager.TriggerEvent(EventName.FaucetRunning);
        }

    }
    
    private void changeColor()
    {
        enabled = false;
    }
}
