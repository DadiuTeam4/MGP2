using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ResourceUI : MonoBehaviour
{

    private UnityAction UIListener;

    public GameObject button;
    private int currentButtonAmount;
    private List<int> listOfPickedUpNumbers;
    static public List<int> listOfPickedUpNumbersState;
    static public List<Vector3> listOfPickedUpNumbersPosition;

    private RectTransform canvasRectTransform;
    private float heightOfCanvas, widthOfCanvas;
    public float heightOfButton = 70, widthOfButton = 70;
    private int amountOfCollectedNumbers;
    private float canvasRatio;

    public Sprite[] spriteForUI = new Sprite[6];

    // Use this for initialization
    void Start()
    {

        UIListener = new UnityAction(UpdateUI);
        EventManager.StartListening(EventName.UIUpdate, UIListener);

        canvasRectTransform = GetComponent<RectTransform>();

        heightOfCanvas = canvasRectTransform.rect.height;

        widthOfCanvas = canvasRectTransform.rect.width;

        CalculateCanvasRatio();

        UpdateUI();
    }


    private void UpdateUI()
    {
        listOfPickedUpNumbers = ResourceManager.GetListOfPickedUpNumbers();
        listOfPickedUpNumbersState = ResourceManager.GetListOfPickedUpNumbersState();
        listOfPickedUpNumbersPosition = ResourceManager.GetListOfPickedUpPosition();

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
        if (Input.GetKeyDown("e"))
        {
            EventManager.TriggerEvent(EventName.NumberThreePickedUp);
        }
        if (Input.GetKeyDown("r"))
        {
            EventManager.TriggerEvent(EventName.NumberFourPickedUp);
        }
        if (Input.GetKeyDown("t"))
        {
            EventManager.TriggerEvent(EventName.NumberFivePickedUp);
        }
        if (Input.GetKeyDown("y"))
        {
            EventManager.TriggerEvent(EventName.NumberSixPickedUp);
        }
    }

    private void GenerateButtons()
    {
        GameObject g;
        RectTransform rectTransform;
        ButtonController buttonController;
        for (int i = currentButtonAmount; i < amountOfCollectedNumbers; i++)
        {
            g = Instantiate(button, transform);
            g.transform.GetChild(0).GetComponent<Text>().text = listOfPickedUpNumbers[i].ToString();

            Image myImageComponent = g.GetComponent<Image>();
            myImageComponent.sprite = spriteForUI[listOfPickedUpNumbers[i] - 1];

            rectTransform = g.GetComponent<RectTransform>();
            rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, widthOfButton);
            rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, heightOfButton);
            
			if (TestIfIsFristTime(listOfPickedUpNumbersPosition[i]))
            {
                rectTransform.localPosition = PositionGenerator(listOfPickedUpNumbers[i]);
            }
            else
            {
                rectTransform.anchoredPosition = listOfPickedUpNumbersPosition[i];
            }

            buttonController = g.GetComponent<ButtonController>();
			buttonController.buttonIndex = i;
            buttonController.eventName = SetButtonEnum(listOfPickedUpNumbers[i]);
            buttonController.SetOriginalPosition(rectTransform.localPosition);
            buttonController.SetState(listOfPickedUpNumbersState[i]);
            buttonController.canvasRect = canvasRectTransform;
        }

        currentButtonAmount = amountOfCollectedNumbers;
    }

    private bool TestIfIsFristTime(Vector3 pos)
    {
        if (pos.x == 0 && pos.y == 0 && pos.z == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private Vector3 PositionGenerator(int currentNumber)
    {

        int randomLogicVariable = Random.Range(1, 5);
        int randomCornerX = 1;
        int randomCornerY = 1;
        int moveWithOrHeight = Random.Range(0, 2); ;

        switch (randomLogicVariable)
        {
            case 1:
                randomCornerX = 1;
                randomCornerY = 1;
                break;
            case 2:
                randomCornerX = -1;
                randomCornerY = 1;
                break;
            case 3:
                randomCornerX = 1;
                randomCornerY = -1;
                break;
            case 4:
                randomCornerX = -1;
                randomCornerY = -1;
                break;

        }

        Vector3 myPosition = new Vector3(randomCornerX * widthOfCanvas / 2 - randomCornerX * widthOfButton / 2 - randomCornerX * moveWithOrHeight * ((currentNumber * widthOfButton)),
                                         randomCornerY * heightOfCanvas / 2 - randomCornerY * heightOfButton / 2 - randomCornerY * ((moveWithOrHeight + 1) % 2) * ((currentNumber * heightOfButton)),
                                        0);

        return myPosition;
    }


    private void CalculateButtonSize()
    {
        widthOfButton *= canvasRatio;
        heightOfButton = widthOfButton;
    }

    private void CalculateCanvasRatio()
    {
        canvasRatio = heightOfCanvas / widthOfCanvas;
    }

    private EventName SetButtonEnum(int index)
    {
        switch (index)
        {
            case 1:
                return EventName.NumberOneClicked;

            case 2:
                return EventName.NumberTwoClicked;
            case 3:
                return EventName.NumberThreeClicked;
            case 4:
                return EventName.NumberFourClicked;
            case 5:
                return EventName.NumberFiveClicked;
            case 6:
                return EventName.NumberSixClicked;
            default:
                Debug.LogError("ResourceUI: INDEX OUT OF SWITCH CASE RANGE");
                return EventName.Test;
        }
    }

}
