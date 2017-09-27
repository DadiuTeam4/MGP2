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
	
	// Use this for initialization
	void Start ()
	{

		UIListener = new UnityAction(UpdateUI);
		EventManager.StartListening(EventName.UIUpdate, UIListener);

		canvasRectTransform = GetComponent<RectTransform>();

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
		RectTransform temp;
		for (int i = currentButtonAmount; i < amountOfCollectedNumbers; i++)
		{
			g = Instantiate(button, new Vector3(0, 0, 0), Quaternion.identity);
			g.transform.SetParent(transform);
			temp = g.GetComponent<RectTransform>();
			temp.sizeDelta = new Vector2(widthOfButton, heightOfButton);
			temp.localPosition = new Vector3((i * widthOfButton - widthOfCanvas/2) + widthOfButton/2, heightOfCanvas/2 - heightOfButton/2, 0);
			g.transform.GetChild(0).GetComponent<Text>().text = listOfPickedUpNumbers[i].ToString();
			g.GetComponent<ButtonController>().eventName = SetButtonEnum(listOfPickedUpNumbers[i]);
			g.GetComponent<BoxCollider>().size = new Vector3 (temp.sizeDelta.x, temp.sizeDelta.y, 1.0f);
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
