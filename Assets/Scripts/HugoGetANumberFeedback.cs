using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HugoGetANumberFeedback : MonoBehaviour
{

    public ParticleSystem getNumberFeedbackPS;

    void Start()
    {
        EventManager.StartListening(EventName.HugoGetANumberFeedBack, PlayPSWhenGetANumber);
    }

    private void PlayPSWhenGetANumber()
    {
        if (getNumberFeedbackPS == null)
        {
            Debug.LogError("The particle system of Hugo Get A Number successfully shouldn't be null");
        }
        else
        {
			Debug.Log("Play on success feedback");
            getNumberFeedbackPS.transform.position = gameObject.transform.position;
            getNumberFeedbackPS.Emit(20);
        }
    }

}
