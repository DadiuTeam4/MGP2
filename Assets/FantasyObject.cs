//Author: Do not known
//Contributor: You Wu
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FantasyObject : MonoBehaviour
{

    public EventName spawnOnEvent;
    // Use this for initialization
    void Start()
    {
        int fantasyNumber = EventManager.NumberEventToInt(spawnOnEvent);
        if (!ResourceManager.NumberCountedToGrandma(fantasyNumber))
        {
            DeactivateFantasyObject();
            EventManager.StartListening(spawnOnEvent, ActivateFantasyObject);
        }
    }
    void ActivateFantasyObject()
    {
        gameObject.GetComponentInChildren<Renderer>().enabled = true;
    }

    void DeactivateFantasyObject()
    {
        gameObject.GetComponentInChildren<Renderer>().enabled = false;
    }


}
