//Author: You Wu
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{

    private Renderer render;
    // Use this for initialization
    void Start()
    {
        render = gameObject.GetComponent<Renderer>();
        EventManager.StartListening(EventName.LightswitchClicked, RenderTheGhostOrNot);
    }

    private void RenderTheGhostOrNot()
    {
        if (ResourceManager.kitchenLightOn == true)
        {
            render.enabled = false;
        }
        else
        {
            render.enabled = true;
        }
    }

}
