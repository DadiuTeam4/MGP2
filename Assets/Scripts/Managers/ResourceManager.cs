﻿/*Author:Tilemachos
Co-author: Jonathan (worked on this Wednesday)
This script holds the current level the player is on,
which number he/she has collected
and which levels hae been complited

NOTICE: The ResourceManager has been appointed the
place for keeping ALL STATE, this is what is currently
being implemented.

 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ResourceManager : Singleton<ResourceManager>
{
	//To do: Implement enums instead of string for CurrentSceneName

	private UnityAction resourceManagerListenerForNumber1;
	private UnityAction resourceManagerListenerForNumber2;
	private UnityAction resourceManagerListenerForNumber3;
	private UnityAction resourceManagerListenerForNumber4;
	private UnityAction resourceManagerListenerForNumber5;
	private UnityAction resourceManagerListenerForNumber6;



	private UnityAction resourceManagerListenerForNumber1Clicked;
	private UnityAction resourceManagerListenerForNumber2Clicked;
	private UnityAction resourceManagerListenerForNumber3Clicked;
	private UnityAction resourceManagerListenerForNumber4Clicked;
	private UnityAction resourceManagerListenerForNumber5Clicked;
	private UnityAction resourceManagerListenerForNumber6Clicked;


    private UnityAction sceneTriggerListener;


	// State holder variables.
	public static bool doorToKitchenOpen;
	public static bool kitchenSinkFull;
	public static bool kitchenLightOn;
	public static bool isFantasyObjectActivated;
	public static bool isOvenDoorOpen;
	static private string currentSceneName = "HubScene";
	static public List<int> listOfPickedUpNumbers;
	static public List<int> listOfPickedUpNumbersState;
	static public List<Vector3> listOfPickedUpNumbersPosition;

	 void Start()
	 {

		 listOfPickedUpNumbers = new List<int>{ 1, 2, 3, 4, 5, 6 };
		 listOfPickedUpNumbersState = new List<int>();
		 listOfPickedUpNumbersPosition = new List<Vector3>();
		 for (int i = 0; i < listOfPickedUpNumbers.Count; i++)
		 {
			listOfPickedUpNumbersPosition.Add(new Vector3(0f, 0f, 0f));
			listOfPickedUpNumbersState.Add(-1);
		 }

		 resourceManagerListenerForNumber1 = new UnityAction(AddNumber1ToListOfPickedUpNumbers);
		 resourceManagerListenerForNumber2 = new UnityAction(AddNumber2ToListOfPickedUpNumbers);
		 resourceManagerListenerForNumber3 = new UnityAction(AddNumber3ToListOfPickedUpNumbers);
		 resourceManagerListenerForNumber4 = new UnityAction(AddNumber4ToListOfPickedUpNumbers);
		 resourceManagerListenerForNumber5 = new UnityAction(AddNumber5ToListOfPickedUpNumbers);
		 resourceManagerListenerForNumber6 = new UnityAction(AddNumber6ToListOfPickedUpNumbers);


		EventManager.StartListening(EventName.NumberOnePickedUp, resourceManagerListenerForNumber1);
		EventManager.StartListening(EventName.NumberTwoPickedUp, resourceManagerListenerForNumber2);
		EventManager.StartListening(EventName.NumberThreePickedUp, resourceManagerListenerForNumber3);
		EventManager.StartListening(EventName.NumberFourPickedUp, resourceManagerListenerForNumber4);
		EventManager.StartListening(EventName.NumberFivePickedUp, resourceManagerListenerForNumber5);
		EventManager.StartListening(EventName.NumberSixPickedUp, resourceManagerListenerForNumber6);


		 resourceManagerListenerForNumber1Clicked = new UnityAction(Number1Deactive);
		 resourceManagerListenerForNumber2Clicked = new UnityAction(Number2Deactive);
		 resourceManagerListenerForNumber3Clicked = new UnityAction(Number3Deactive);
		 resourceManagerListenerForNumber4Clicked = new UnityAction(Number4Deactive);
		 resourceManagerListenerForNumber5Clicked = new UnityAction(Number5Deactive);
		 resourceManagerListenerForNumber6Clicked = new UnityAction(Number6Deactive);

		EventManager.StartListening(EventName.NumberOneClicked, resourceManagerListenerForNumber1Clicked);
		EventManager.StartListening(EventName.NumberTwoClicked, resourceManagerListenerForNumber2Clicked);
		EventManager.StartListening(EventName.NumberThreeClicked, resourceManagerListenerForNumber3Clicked);
		EventManager.StartListening(EventName.NumberFourClicked, resourceManagerListenerForNumber4Clicked);
		EventManager.StartListening(EventName.NumberFiveClicked, resourceManagerListenerForNumber5Clicked);
		EventManager.StartListening(EventName.NumberSixClicked, resourceManagerListenerForNumber6Clicked);


        EventManager.StartListening(EventName.HubSceneLoaded, ChangeToHubScene);

        EventManager.StartListening(EventName.HubDoorClicked, ChangeToKitchenScene);

		EventManager.StartListening(EventName.KitchenDoorClicked, ChangeToHubScene);

        EventManager.StartListening(EventName.LanguageSelected, ChangeToHubScene);

		doorToKitchenOpen = false;
		kitchenSinkFull = false;
		kitchenLightOn = true;
		isFantasyObjectActivated = false;
		isOvenDoorOpen = false;		
	 }



	public static string GetCurrentSceneName()
	{
		return currentSceneName;
	}
    void ChangeToKitchenScene()
    {
		currentSceneName = "KitchenScene";
    }

	void ChangeToHubScene()
    {
		currentSceneName = "HubScene";
    }
	public static List<int> GetListOfPickedUpNumbersState()
	{
		return listOfPickedUpNumbersState;
	}
	public static List<int> GetListOfPickedUpNumbers()
	{
		return listOfPickedUpNumbers;
	}

	public static List<Vector3> GetListOfPickedUpPosition()
	{
		return listOfPickedUpNumbersPosition;
	}
	public static void ClearListOfPickedUpNumbers()
	{
		listOfPickedUpNumbers.Clear();
	}
	public static void DeleteNumberOfListOfPickedUpNumbers(int deleteThisNumber)
	{
		listOfPickedUpNumbers.Remove(deleteThisNumber);
	}
	private static void AddNumber1ToListOfPickedUpNumbers()
	{

		listOfPickedUpNumbersState[0] = 1;
		
		EventManager.TriggerEvent(EventName.UIUpdate);

	}
	private static void AddNumber2ToListOfPickedUpNumbers()
	{

		listOfPickedUpNumbersState[1] = 1;
		
		EventManager.TriggerEvent(EventName.UIUpdate);

	}	
	private static void AddNumber3ToListOfPickedUpNumbers()
	{

		listOfPickedUpNumbersState[2] = 1;
		EventManager.TriggerEvent(EventName.UIUpdate);
	}
	private static void AddNumber4ToListOfPickedUpNumbers()
	{


		listOfPickedUpNumbersState[3] = 1;

		EventManager.TriggerEvent(EventName.UIUpdate);
	}	
	private static void AddNumber5ToListOfPickedUpNumbers()
	{


		listOfPickedUpNumbersState[4] = 1;

		EventManager.TriggerEvent(EventName.UIUpdate);
	}	
	private static void AddNumber6ToListOfPickedUpNumbers()
	{


		listOfPickedUpNumbersState[5] = 1;

		EventManager.TriggerEvent(EventName.UIUpdate);
	}

    public static bool NumberFound(int nr)
    {
        return listOfPickedUpNumbersState[nr-1] == 1;
    }

    public static bool NumberCountedToGrandma(int nr)
    {
		return listOfPickedUpNumbersState[nr-1] == 0;
    }

    private static void Number1Deactive()
	{
		int index = listOfPickedUpNumbers.FindIndex(x => x == 1);
		listOfPickedUpNumbersState[index] = 0;
	}
	private static void Number2Deactive()
	{
		int index = listOfPickedUpNumbers.FindIndex(x => x == 2);
		listOfPickedUpNumbersState[index] = 0;
	}
	private static void Number3Deactive()
	{
		int index = listOfPickedUpNumbers.FindIndex(x => x == 3);
		listOfPickedUpNumbersState[index] = 0;
	}
	private static void Number4Deactive()
	{
		int index = listOfPickedUpNumbers.FindIndex(x => x == 4);
		listOfPickedUpNumbersState[index] = 0;
	}
	private static void Number5Deactive()
	{
		int index = listOfPickedUpNumbers.FindIndex(x => x == 5);
		listOfPickedUpNumbersState[index] = 0;
	}
	private static void Number6Deactive()
	{
		int index = listOfPickedUpNumbers.FindIndex(x => x == 6);
		listOfPickedUpNumbersState[index] = 0;
	}

	public static void ResetState()
	{
		doorToKitchenOpen = false;
		kitchenSinkFull = false;
		kitchenLightOn = true;
		isFantasyObjectActivated = false;
		isOvenDoorOpen = false;

		for (int i = 0; i < listOfPickedUpNumbers.Count; i++)
		{
			listOfPickedUpNumbersState[i] = -1;
		}
	}
}
