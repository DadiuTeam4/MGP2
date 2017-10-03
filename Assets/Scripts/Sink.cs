// Author: Jonathan

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sink : Interactable 
{

	void Start ()
	{
        EventManager.StartListening(EventName.NumberFourPickedUp, FillSink);		
	}
	
	void Update () {
		
	}

    void FillSink()
    {
        ResourceManager.kitchenSinkFull = true;
    }
}
