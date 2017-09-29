﻿//Author: Do not known
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
        if (!ResourceManager.isFantasyObjectActivated)
        {
            DeactivateFantasyObject();
            EventManager.StartListening(spawnOnEvent, ActivateFantasyObject);
        }
    }
    void ActivateFantasyObject()
    {
        gameObject.GetComponentInChildren<Renderer>().enabled = true;
        ResourceManager.isFantasyObjectActivated = true;
    }

    void DeactivateFantasyObject()
    {
        gameObject.GetComponentInChildren<Renderer>().enabled = false;
    }
}
