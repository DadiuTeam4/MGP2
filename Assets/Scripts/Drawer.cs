//Contributor: Itai Yavin

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawer : Interactable {

	private bool isBeingPlayed = false;
	private bool drawerOpen = false;
	private Vector3 startPosition;
	private Vector3 endPosition;
	private bool isBeingPulled;

	[Tooltip("The position the drawer pulls to")]
	public Transform pullPositionTransform;

	[Tooltip("Amount of which the drawer is pulled out per interval")]
	[Range(0.01f, 1.0f)] 
	public float pullAmount = 0.05f;

	[Tooltip("Interval between each pull, in seconds")]
	[Range(0.01f, 1.0f)]
	public float pullInterval = 0.05f;

	void Start()
	{
		startPosition = transform.position;
		endPosition = pullPositionTransform.position;
	}

	public override void OnTouchBegin()
	{	
		if(!isBeingPulled)
		{
			StartCoroutine("LerpDrawerPosition");
		}

		if (isBeingPlayed == false && drawerOpen == false)
		{
			AkSoundEngine.PostEvent ("Play_MGP2_SD_DrawerOpen", gameObject, (uint)AkCallbackType.AK_EndOfEvent, EventHasStopped, 1); 
			isBeingPlayed = true;
			drawerOpen = true; 
		}

		if (isBeingPlayed == false && drawerOpen == true)
		{
			AkSoundEngine.PostEvent ("Play_MGP2_SD_DrawerClose", gameObject, (uint)AkCallbackType.AK_EndOfEvent, EventHasStopped, 1); 
			isBeingPlayed = true;
			drawerOpen = false; 
		}
	}
	void EventHasStopped(object in_cookie, AkCallbackType in_type, object in_info)
	{
		if (in_type == AkCallbackType.AK_EndOfEvent)
		{
			isBeingPlayed = false; 
		}
	}

	private IEnumerator LerpDrawerPosition()
	{
		isBeingPulled = true;

		float t = 0;
		while(t < 1)
		{
			t += pullAmount;
			transform.position = Vector3.Lerp(startPosition, endPosition, t);
			yield return new WaitForSeconds(pullInterval);
		}
		
		Vector3 temp = startPosition;
		startPosition = endPosition;
		endPosition = temp;

		isBeingPulled = false;
	}
}