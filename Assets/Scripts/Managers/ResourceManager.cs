/*Author:Tilemachos
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
	static private string currentSceneName = "IntroLevel";
	static public List<int> listOfPickedUpNumbers;
	static private List<string> listOfScenesCompleted;
	private UnityAction resourceManagerListenerForNumber1;
	private UnityAction resourceManagerListenerForNumber2;
	private UnityAction resourceManagerListenerForNumber3;
	private UnityAction resourceManagerListenerForNumber4;
	private UnityAction resourceManagerListenerForNumber5;
	private UnityAction resourceManagerListenerForNumber6;
	private UnityAction resourceManagerListenerForNumber7;
	private UnityAction resourceManagerListenerForNumber8;
	private UnityAction resourceManagerListenerForNumber9;
	private UnityAction resourceManagerListenerForNumber10;

	// State holder variables.
	public static bool doorToKitchenOpen;

	// public bool kitchenLightOn = true;

	public static bool kitchenSinkFull;

	 void Start()
	 {

		 listOfPickedUpNumbers = new List<int>();
		 listOfScenesCompleted = new List<string>();


		 resourceManagerListenerForNumber1 = new UnityAction(AddNumber1ToListOfPickedUpNumbers);
		 resourceManagerListenerForNumber2 = new UnityAction(AddNumber2ToListOfPickedUpNumbers);
		 resourceManagerListenerForNumber3 = new UnityAction(AddNumber3ToListOfPickedUpNumbers);
		/* resourceManagerListenerForNumber4 = new UnityAction(AddNumber4ToListOfPickedUpNumbers);
		 resourceManagerListenerForNumber5 = new UnityAction(AddNumber5ToListOfPickedUpNumbers);
		 resourceManagerListenerForNumber6 = new UnityAction(AddNumber6ToListOfPickedUpNumbers);
		 resourceManagerListenerForNumber7 = new UnityAction(AddNumber7ToListOfPickedUpNumbers);
		 resourceManagerListenerForNumber8 = new UnityAction(AddNumber8ToListOfPickedUpNumbers);
		 resourceManagerListenerForNumber9 = new UnityAction(AddNumber9ToListOfPickedUpNumbers);
		 resourceManagerListenerForNumber10 = new UnityAction(AddNumber10ToListOfPickedUpNumbers);*/


		EventManager.StartListening(EventName.NumberOnePickedUp, resourceManagerListenerForNumber1);
		EventManager.StartListening(EventName.NumberTwoPickedUp, resourceManagerListenerForNumber2);
		EventManager.StartListening(EventName.NumberThreePickedUp, resourceManagerListenerForNumber3);
		/*EventManager.StartListening("number4HasBeenPickedUp", resourceManagerListenerForNumber4);
		EventManager.StartListening("number5HasBeenPickedUp", resourceManagerListenerForNumber5);
		EventManager.StartListening("number6HasBeenPickedUp", resourceManagerListenerForNumber6);
		EventManager.StartListening("number7HasBeenPickedUp", resourceManagerListenerForNumber7);
		EventManager.StartListening("number8HasBeenPickedUp", resourceManagerListenerForNumber8);
		EventManager.StartListening("number9HasBeenPickedUp", resourceManagerListenerForNumber9);
		EventManager.StartListening("number10HasBeenPickedUp", resourceManagerListenerForNumber10);*/

		doorToKitchenOpen = false;
		kitchenSinkFull = false;
	 }


	public static string GetCurrentSceneName()
	{
		return currentSceneName;
	}

	public static void SetCurrentSceneName(string newSceneName)
	{
		currentSceneName = newSceneName;
	}


	public static List<int> GetListOfPickedUpNumbers()
	{
		return listOfPickedUpNumbers;
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
		//print(" 1 has been picked up");
		listOfPickedUpNumbers.Add(1);
		EventManager.TriggerEvent(EventName.UIUpdate);

		//SceneManager.LoadScene("ResourceManagerTestScene2");
	}
	private static void AddNumber2ToListOfPickedUpNumbers()
	{
		listOfPickedUpNumbers.Add(2);
		EventManager.TriggerEvent(EventName.UIUpdate);

	}	
	private static void AddNumber3ToListOfPickedUpNumbers()
	{
		listOfPickedUpNumbers.Add(3);
		EventManager.TriggerEvent(EventName.UIUpdate);

	}
	private static void AddNumber4ToListOfPickedUpNumbers()
	{
		listOfPickedUpNumbers.Add(4);
	}	
	private static void AddNumber5ToListOfPickedUpNumbers()
	{
		listOfPickedUpNumbers.Add(5);
	}	
	private static void AddNumber6ToListOfPickedUpNumbers()
	{
		listOfPickedUpNumbers.Add(6);
	}	
	private static void AddNumber7ToListOfPickedUpNumbers()
	{
		listOfPickedUpNumbers.Add(7);
	}	
	private static void AddNumber8ToListOfPickedUpNumbers()
	{
		listOfPickedUpNumbers.Add(8);
	}	
	private static void AddNumber9ToListOfPickedUpNumbers()
	{
		listOfPickedUpNumbers.Add(9);
	}	
	private static void AddNumber10ToListOfPickedUpNumbers()
	{
		listOfPickedUpNumbers.Add(10);
	}



	public static List<string> GetListOfScenesCompleted()
	{
		return listOfScenesCompleted;
	}
	public static void ClearListOfScenesCompleted()
	{
		listOfScenesCompleted.Clear();
	}
	public static void DeleteLevelInListOfScenesCompleted(string deleteThisSceneFromTheList)
	{
		listOfScenesCompleted.Remove(deleteThisSceneFromTheList);
	}
	public static void AddLevelToListOfScenesCompleted(string addThisScene)
	{
		listOfScenesCompleted.Add(addThisScene);
	}
}
