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
        int fantasyNumber = NumberEventToInt(spawnOnEvent);
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

    int NumberEventToInt(EventName numberEvent)
    {
        switch (numberEvent)
        {
            case EventName.NumberOnePickedUp:
            case EventName.NumberOneClicked:
                return 1;
            case EventName.NumberTwoPickedUp:
            case EventName.NumberTwoClicked:
                return 2;
            case EventName.NumberThreePickedUp:
            case EventName.NumberThreeClicked:
                return 3;
            case EventName.NumberFourClicked:     
            case EventName.NumberFourPickedUp:
                return 4;
            case EventName.NumberFiveClicked:
            case EventName.NumberFivePickedUp:
                return 5;
            case EventName.NumberSixClicked:
            case EventName.NumberSixPickedUp:
                return 6;
            default:
                Debug.LogError("Wrong event on FantasyObject: " + gameObject.name);
                return -1;
        }
    }
}
