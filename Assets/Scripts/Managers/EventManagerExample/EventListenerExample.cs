using UnityEngine;
using UnityEngine.Events;

//Init the listener On Awake.
//Start listening event on the game object enabled.
//Stop listening event on the game object disabled.
//If there is a listener like Destrory
//Remember to invoke stopListening just to make sure
//the listening is stopped.
public class EventListenerExample : MonoBehaviour
{
    private UnityAction someListener;

    void Awake()
    {
        someListener = new UnityAction(someFunction);
    }

    void OnEnable()
    {
		EventManager.StartListening("test", someListener);
    }

    void OnDisable()
    {
		EventManager.StopListening("test", someListener);
    }

    void someFunction()
    {
		Debug.Log("Some function is called!");
    }
}
