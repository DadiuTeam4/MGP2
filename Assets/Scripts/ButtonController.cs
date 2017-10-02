using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonController : MonoBehaviour {
	[HideInInspector]
	public EventName eventName;
	[HideInInspector]
	public int buttonIndex; 
	[HideInInspector]
	public RectTransform canvasRect;
	private RectTransform buttonRect;
	private bool buttonHeld;
	private bool active;
	private Vector3 originalPosition;
	public Collider targetCollider;
	private string currentScene;
	private string nameOfSceneThatHugoCanCount = "HubScene";
	private bool isBeingPlayed = false; 
	private Vector2 mouseInCanvasPosition;
		
	void Start()
	{
		buttonRect = GetComponent<RectTransform>();
		GameObject targetGameObject;
		targetGameObject = GameObject.Find("Hugo");
		targetCollider = targetGameObject.GetComponent<Collider>();

		currentScene = ResourceManager.GetCurrentSceneName();

	}

	void Update()
	{
		if (ResourceManager.listOfPickedUpNumbersState[buttonIndex] == 1)
		{
			active = true;
			var color = GetComponent<Image> ().color;
			color = Color.white;
			GetComponent<Image> ().color = color;
		}
		else if(ResourceManager.listOfPickedUpNumbersState[buttonIndex] == 0)
		{
			active = false;			
		}
				
		if (buttonHeld)
		{
			RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, Input.mousePosition, Camera.main, out mouseInCanvasPosition);
			buttonRect.localPosition = mouseInCanvasPosition;

			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (targetCollider.Raycast(ray, out hit, 100.0F))
			{
				if (currentScene == nameOfSceneThatHugoCanCount && active)
				{
					active = false;
					buttonHeld = false;

					var color = GetComponent<Image> ().color;
					color = Color.red;
					GetComponent<Image> ().color = color;
					EventManager.TriggerEvent(eventName);
					EventManager.TriggerEvent(EventName.HugoGetANumberFeedBack);
				}
				else
				{
					if (isBeingPlayed == false) 
					{
						FortaelleBedstemor (); 
					}
				}


			}

		}
	}
	
	public void OnPointerDown()
	{
		buttonHeld = true;
		EventManager.TriggerEvent(EventName.HugoParticleFeedbackOn);
	}

	public void SetOriginalPosition(Vector3 localOriginalPosition)
	{
		originalPosition = localOriginalPosition;
	}
	public void SetState(int myState)
	{
		if (myState < 1)
		{
			active = false;
		}
		else
		{
			active = true;
		}
		if (myState == 0)
		{
			var color = GetComponent<Image> ().color;
			color = Color.red;
			GetComponent<Image> ().color = color;
		}
		else if (myState == -1)
		{
			var color = GetComponent<Image> ().color;
			color = Color.black;
			GetComponent<Image> ().color = color;
		}
	}
	public void OnPointerUp()
	{
		buttonHeld = false;
		//buttonRect.localPosition = originalPosition;
		EventManager.TriggerEvent(EventName.HugoParticleFeedbackOff);
		ResourceManager.listOfPickedUpNumbersPosition[buttonIndex] = buttonRect.anchoredPosition;
	}

	void FortaelleBedstemor()
	{
		AkSoundEngine.PostEvent ("Play_MGP2_Speak_FortaelleBedstemor", gameObject, (uint)AkCallbackType.AK_EndOfEvent, EventHasStopped, 1);
		isBeingPlayed = true;
	}

	void EventHasStopped(object in_cookie, AkCallbackType in_type, object in_info)
	{
		if (in_type == AkCallbackType.AK_EndOfEvent)
		{
			isBeingPlayed = false; 
		}
	}

}
