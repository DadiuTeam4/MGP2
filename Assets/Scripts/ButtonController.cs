using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(UIRaycaster))]
public class ButtonController : MonoBehaviour {
	[HideInInspector]
	public EventName eventName;
	[HideInInspector]
	public RectTransform canvasRect;
	
	private UIRaycaster uIRaycaster;
	private RectTransform buttonRect;
	private bool buttonHeld;
	private bool active;
	private Vector3 originalPosition;
	public Collider targetCollider;
	private string currentScene;
	private string nameOfSceneThatHugoCanCount = "HubScene";
	private bool isBeingPlayed = false; 

	void Start()
	{
		uIRaycaster = GetComponent<UIRaycaster>();
		buttonRect = GetComponent<RectTransform>();
		GameObject targetGameObject;
		targetGameObject = GameObject.Find("Hugo");
		targetCollider = targetGameObject.GetComponent<Collider>();

		currentScene = ResourceManager.GetCurrentSceneName();

	}

	void Update()
	{
		if (buttonHeld)
		{
			buttonRect.anchoredPosition = uIRaycaster.GetRaycastedPositionOnCanvas();

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (targetCollider.Raycast(ray, out hit, 100.0F))
			{
				if (currentScene == nameOfSceneThatHugoCanCount && active)
				{
					active = false;
					buttonHeld = false;

					buttonRect.localPosition = originalPosition;
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
	public void SetActiveBool(bool myState)
	{
		active = myState;
		if (!active)
		{
			var color = GetComponent<Image> ().color;
			color = Color.red;
			GetComponent<Image> ().color = color;
		}
	}
	public void OnPointerUp()
	{
		buttonHeld = false;
		//buttonRect.localPosition = originalPosition;
		EventManager.TriggerEvent(EventName.HugoParticleFeedbackOff);
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
