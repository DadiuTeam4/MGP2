//Author: You Wu
//Contributor:
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//Event Manager can register listeners by startListening
//Event Manager can remove listeners by stopListening
//Trigger the event and all specific method.
public class EventManager : Singleton<EventManager>
{
    //use the value of Enum as its id. Just use (int)EventName.Name
    private Dictionary<int, UnityEvent> eventDictionary;

    void Awake()
    {
        Init();
    }
    void Init()
    {
        DontDestroyOnLoad(transform.gameObject);
        if (eventDictionary == null)
        {
            eventDictionary = new Dictionary<int, UnityEvent>();
        }
    }

    public static void StartListening(int eventName, UnityAction listener)
    {
        UnityEvent thisEvent = null;
        if (Instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.AddListener(listener);
        }
        else
        {
            thisEvent = new UnityEvent();
            thisEvent.AddListener(listener);
            Instance.eventDictionary.Add(eventName, thisEvent);
        }
    }

    public static void StopListening(int eventName, UnityAction listener)
    {
        if (instance == null)
        {
            return;
        }
        UnityEvent thisEvent = null;
        if (Instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.RemoveListener(listener);
        }
    }

    public static void TriggerEvent(int eventName)
    {
        UnityEvent thisEvent = null;
        if (Instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.Invoke();
        }
        else
        {
            Debug.LogError("The event name " + eventName + " does not exist");
        }
    }

}

//Add all the event name here
//Use (int) to convert event name to its id
//Id starts from 0, 1, 2 ...
public enum EventName 
{
    Test, 
    NumberThreePickedUp, 
    KitchenDoorClicked,
    HubDoorClicked,
}