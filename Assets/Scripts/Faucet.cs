//Author: You Wu
//Contributor:
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Faucet : NumberFoundInteractable
{

    void Start()
    {
    }

    void Update()
    {
        if(timeHeld > 2)
        {
            changeColor();
            //Fire a event here
        }

    }
    
    private void changeColor()
    {
        enabled = false;
    }


}
