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
    private Dictionary<EventName, IntUnityEvent> intEventDictionary;
    private Dictionary<EventName, UnityEvent> eventDictionary;

    void Awake()
    {
        Init();
    }
    void Init()
    {

        if (eventDictionary == null)
        {
            eventDictionary = new Dictionary<EventName, UnityEvent>();
            intEventDictionary = new Dictionary<EventName, IntUnityEvent>();
        }
    }

    public static void StartListening(EventName eventName, UnityAction<int> listener, int parameter) 
    {
        IntUnityEvent thisEvent = null;
        if (Instance.intEventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.AddListener(listener);
        }
        else
        {
            thisEvent = new IntUnityEvent();
            thisEvent.parameter = parameter;
            thisEvent.AddListener(listener);
            Instance.intEventDictionary.Add(eventName, thisEvent);
        }
    }

    public static void StartListening(EventName eventName, UnityAction listener)
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

    public static void StopListening(EventName eventName, UnityAction<int> listener)
    {
        if (instance == null)
        {
            return;
        }
        IntUnityEvent thisEvent = null;
        if (Instance.intEventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.RemoveListener(listener);
        }
    }

    public static void StopListening(EventName eventName, UnityAction listener)
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

    public static void TriggerEvent(EventName eventName)
    {
        IntUnityEvent thisIntEvent = null;
        UnityEvent thisEvent = null;
        if (Instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.Invoke();
        }
        else if (Instance.intEventDictionary.TryGetValue(eventName, out thisIntEvent)) 
        {
            thisIntEvent.Invoke(thisIntEvent.parameter);
        }
        else
        {
            Debug.LogError("The event name " + eventName + " does not exist");
        }
    }

}

//Add all the event names here.
public enum EventName
{
    Test, 
    NumberPickedUp,
    NumberOnePickedUp,
    NumberTwoPickedUp,
    NumberThreePickedUp,
    NumberFourPickedUp,
    NumberFivePickedUp,
    NumberSixPickedUp,
    KitchenDoorClicked, 
    HubDoorClicked, 
    CookieJarTouched, 
    KitchenSceneLoaded, 
    HubSceneLoaded,
    LangEnglish, 
    LangDanish, 
    LanguageSelected,
    UIUpdate,
    NumberOneClicked,
    NumberTwoClicked,
    NumberThreeClicked,
    NumberFourClicked,
    NumberFiveClicked,
    NumberSixClicked,
    FaucetRunning,
    LightswitchClicked,
    InteractableClicked,
    ShowOnGamOptions

}