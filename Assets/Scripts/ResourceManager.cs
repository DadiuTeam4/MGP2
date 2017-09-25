/*Author:Tilemachos
This script holds the current level the player is on,
which number he/she has collected
and which levels hae been complited

 */

using System.Collections;
using System.Collections.Generic;

public class ResourceManager 
{
	
	static private string currentSceneName = "IntroLevel";
	static private List<int> listOfPickedUpNumbers;
	static private List<string> listOfScenesCompleted;
	 

	 public ResourceManager()
	 {
		 listOfPickedUpNumbers = new List<int>();
		 listOfScenesCompleted = new List<string>();
	 }


	public string GetCurrentSceneName()
	{
		return currentSceneName;
	}

	public void SetCurrentSceneName(string newSceneName)
	{
		currentSceneName = newSceneName;
	}




	public List<int> GetListOfPickedUpNumbers()
	{
		return listOfPickedUpNumbers;
	}
	public void ClearListOfPickedUpNumbers()
	{
		listOfPickedUpNumbers.Clear();
	}
	public void DeleteNumberOfListOfPickedUpNumbers(int deleteThisNumber)
	{
		listOfPickedUpNumbers.Remove(deleteThisNumber);
	}
	public void AddNumberToListOfPickedUpNumbers(int newNumber)
	{
		listOfPickedUpNumbers.Add(newNumber);
	}




	public List<string> GetListOfScenesCompleted()
	{
		return listOfScenesCompleted;
	}
	public void ClearListOfScenesCompleted()
	{
		listOfScenesCompleted.Clear();
	}
	public void DeleteLevelInListOfScenesCompleted(string deleteThisSceneFromTheList)
	{
		listOfScenesCompleted.Remove(deleteThisSceneFromTheList);
	}
	public void AddLevelToListOfScenesCompleted(string addThisScene)
	{
		listOfScenesCompleted.Add(addThisScene);
	}




	
}
