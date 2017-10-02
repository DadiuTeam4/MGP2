//Author: Jonathan
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubberDucksRise : Interactable
{
	public Vector3 endMarker;
	public float journeyTime;

	void Start ()
	{ 
		EventManager.StartListening(EventName.FaucetRunning, CommenceEpicRubberDuckJourney);
		CheckSinkStatus();
	}

	void CommenceEpicRubberDuckJourney()
	{
		StartCoroutine(riseMyDucksRise(gameObject, endMarker, journeyTime));
	}
	
	IEnumerator riseMyDucksRise(GameObject objectToMove, Vector3 end, float journeySeconds)
	{
		Debug.Log("Onwards and upwards!");

		float elapsedTime = 0;
		Vector3 startingPos = objectToMove.transform.position;
		while (elapsedTime < journeySeconds)
		{
			objectToMove.transform.position = Vector3.Lerp(startingPos, end, (elapsedTime / journeySeconds));
			elapsedTime += Time.deltaTime;
			yield return new WaitForEndOfFrame();
		}

		objectToMove.transform.position = end;
	}

	void CheckSinkStatus()
	{
		if (ResourceManager.kitchenSinkFull == true)
		{
			gameObject.transform.position = endMarker;
		}

	}
}
