﻿//Author: You Wu
//Contributor:
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Faucet : NumberFoundInteractable
{

    void Start()
    {

    }

    void Update()
    {
        if(timeHeld > 2)
        {
            EventManager.TriggerEvent(EventName.FaucetRunning);
            //Fire a event here
        }

    }
    



}
