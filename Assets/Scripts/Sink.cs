// Author: Jonathan

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sink : Interactable 
{

	void Start ()
	{
		getSinkState();
		
	}
	
	void Update () {
		
	}

	void getSinkState()
    {
        if (ResourceManager.kitchenSinkFull == true)
        {
            Debug.Log("Kitchen sink state is: Full");
        }
        else{
            Debug.Log("Kitchen sink state is: Empty");
        }
    }

    void fillSink()
    {
        ResourceManager.kitchenSinkFull = true; 

    }
}
