// Author: Jonathan

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sink : Interactable 
{

	void Start ()
	{
		GetSinkState();
        EventManager.StartListening(EventName.FaucetRunning, FillSink);
		
	}
	
	void Update () {
		
	}

	void GetSinkState()
    {
        if (ResourceManager.kitchenSinkFull == true)
        {
            Debug.Log("Kitchen sink state is: Full");
        }
        else{
            Debug.Log("Kitchen sink state is: Empty");
        }
    }

    void FillSink()
    {
        ResourceManager.kitchenSinkFull = true;
        GetSinkState();

    }
}
