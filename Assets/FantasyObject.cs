using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FantasyObject : MonoBehaviour {

    public EventName spawnOnEvent;
	// Use this for initialization
	void Start () {
		DeactivateFantasyObject ();
        EventManager.StartListening(spawnOnEvent, ActivateFantasyObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void ActivateFantasyObject()
    {
        gameObject.GetComponent<Renderer>().enabled = true;
        gameObject.GetComponent<Collider>().enabled = true;
    }

    void DeactivateFantasyObject()
    {
        gameObject.GetComponent<Renderer>().enabled = false;
        gameObject.GetComponent<Collider>().enabled = false;
    }
}
