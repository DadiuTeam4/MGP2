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
            Debug.LogError("The event name " + eventName + " does not have any listeners");
        }
    }

    public static int NumberEventToInt(EventName numberEvent)
    {
        switch (numberEvent)
        {
            case EventName.NumberOnePickedUp:
            case EventName.NumberOneClicked:
                return 1;
            case EventName.NumberTwoPickedUp:
            case EventName.NumberTwoClicked:
                return 2;
            case EventName.NumberThreePickedUp:
            case EventName.NumberThreeClicked:
                return 3;
            case EventName.NumberFourClicked:
            case EventName.NumberFourPickedUp:
                return 4;
            case EventName.NumberFiveClicked:
            case EventName.NumberFivePickedUp:
                return 5;
            case EventName.NumberSixClicked:
            case EventName.NumberSixPickedUp:
                return 6;
            default:
                Debug.LogError("Tried to convert a non-number event to int");
                return -1;
        }
    }
}

//Add all the event names here.
public enum EventName
{
    Test = 0, 
    NumberPickedUp = 1,
    NumberOnePickedUp = 2,
    NumberTwoPickedUp = 3,
    NumberThreePickedUp = 4,
    NumberFourPickedUp = 5,
    NumberFivePickedUp = 6,
    NumberSixPickedUp = 7,
    KitchenDoorClicked = 8, 
    HubDoorClicked = 9, 
    CookieJarTouched = 10, 
    KitchenSceneLoaded = 11, 
    HubSceneLoaded = 12,
    LangEnglish = 13, 
    LangDanish = 14, 
    LanguageSelected = 15,
    UIUpdate = 16,
    NumberOneClicked = 17,
    NumberTwoClicked = 18,
    NumberThreeClicked = 19,
    NumberFourClicked = 20,
    NumberFiveClicked = 21,
    NumberSixClicked = 22,
    FaucetRunning = 23,
    LightswitchClicked = 24,
    InteractableClicked = 25,
    ShowOnGamOptions = 26,
    InverseCameraGyroScopeX = 27,
    EnableOrDisableOptionMenu = 28,
    InverseCameraGyroScopeY = 29,
    HugoParticleFeedbackOn = 30,
    HugoParticleFeedbackOff = 31

}