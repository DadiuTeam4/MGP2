using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ResourceUI : MonoBehaviour {

	private UnityAction UIListener;

	public GameObject button;
	private int currentButtonAmount;
	private List<int> listOfPickedUpNumbers;
	private RectTransform canvasRectTransform;
	private float heightOfCanvas, widthOfCanvas;
	public float heightOfButton = 70, widthOfButton = 70;
	private int amountOfCollectedNumbers = 0;
	private float canvasRatio;
	private GraphicRaycaster graphicRaycaster;
	
	// Use this for initialization
	void Start ()
	{

		UIListener = new UnityAction(UpdateUI);
		EventManager.StartListening(EventName.UIUpdate, UIListener);

		canvasRectTransform = GetComponent<RectTransform>();
		graphicRaycaster = GetComponent<GraphicRaycaster>();

		heightOfCanvas = canvasRectTransform.rect.height;

		widthOfCanvas = canvasRectTransform.rect.width;

		CalculateCanvasRatio();

		CalculateButtonSize();

		UpdateUI();
	}


	private void UpdateUI()
	{
		listOfPickedUpNumbers = ResourceManager.GetListOfPickedUpNumbers();

		if (listOfPickedUpNumbers != null)
		{
			amountOfCollectedNumbers = listOfPickedUpNumbers.Count;
		}

		GenerateButtons();

	}

	void Update()
	{
		if (Input.GetKeyDown("q"))
        {
			EventManager.TriggerEvent(EventName.NumberOnePickedUp);
        }
		if (Input.GetKeyDown("w"))
        {
			EventManager.TriggerEvent(EventName.NumberTwoPickedUp);
        }
	}

	private void GenerateButtons()
	{
		GameObject g;
		RectTransform rectTransform;
		ButtonController buttonController;
		for (int i = currentButtonAmount; i < amountOfCollectedNumbers; i++)
		{
			Debug.Log(amountOfCollectedNumbers);
			g = Instantiate(button, new Vector3(0, 0, 0), Quaternion.identity);
			g.transform.SetParent(transform);
			g.transform.GetChild(0).GetComponent<Text>().text = listOfPickedUpNumbers[i].ToString();
			
			rectTransform = g.GetComponent<RectTransform>();
			rectTransform.sizeDelta = new Vector2(widthOfButton, heightOfButton);
			rectTransform.localPosition = new Vector3((i * widthOfButton - widthOfCanvas/2) + widthOfButton/2, heightOfCanvas/2 - heightOfButton/2, 0);
			
			buttonController = g.GetComponent<ButtonController>();
			buttonController.eventName = SetButtonEnum(listOfPickedUpNumbers[i]);
			buttonController.canvasRect = canvasRectTransform;
			buttonController.graphicRayCaster = graphicRaycaster;
		}

		currentButtonAmount = amountOfCollectedNumbers;
	}

	private void CalculateButtonSize()
	{
		widthOfButton *= canvasRatio;
		heightOfButton = widthOfButton;
	}

	private void CalculateCanvasRatio()
	{
		canvasRatio = heightOfCanvas/widthOfCanvas;
	}

	private EventName SetButtonEnum(int index)
	{
		switch(index)
		{
			case 1:
				return EventName.NumberOneClicked;
				break;
		
			case 2:
				return EventName.NumberTwoClicked;
				break;

			default:
				Debug.LogError("ResourceUI: INDEX OUT OF SWITCH CASE RANGE");
				return EventName.Test;
				break;
		}
	}

}
