//Author: You Wu
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{

    private Renderer render;
    private Collider collider;
    // Use this for initialization
    void Start()
    {
        render = gameObject.GetComponent<Renderer>();
        collider = gameObject.GetComponent<Collider>();
        collider.enabled = false;
        RenderTheGhostOrNot();
        EventManager.StartListening(EventName.LightswitchClicked, RenderTheGhostOrNot);

    }

    private void RenderTheGhostOrNot()
    {
        if (ResourceManager.kitchenLightOn == true)
        {
            render.enabled = false;
            collider.enabled = false;
        }
        else
        {
            render.enabled = true;
            collider.enabled = true;

        }
    }

}
