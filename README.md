# MGP2
### Documentation goes here
#### But what do I put in the documentation?

- Tag uses.
- Layer uses (for collision, culling, and raycasting – essentially, what should be in what layer).
- GUI depths for layers (what should display over what).
- Scene setup.
- Prefab structure of complicated prefabs.
- Idiom preferences.
- Build setup.

Please use markdown syntax for an easily readable format. Checkout www.hackmd.io for a markdown editor.

### Code inspection
Every time you want to commit new scripts and/or changes to scripts, you have to run the code inspection script in order to determine whether your code is up to Code Convention Standards^tm^. It is called *inspectCode.py* and is located in the root folder of the project.

#### Setup
Requirements are [Python](https://www.python.org/downloads/) (whatever version) and the [ReSharper Command Line Tools](https://www.jetbrains.com/resharper/download/index.html#section=resharper-clt). 

If you are on Windows, you have to extract the command line tools to any folder and adding that folder to your *Path*. This is done by searching for *Edit the system environment variables* -> Click *Environment variables* -> Double-click *Path* -> Click *New* and write the directory to the folder where you extracted the ReSharper Command Line Tools. The code inspector executable should now be callable from anywhere in your system.

#### Usage
Simply run the *inspectCode.py* script by double-clicking it, or by running 
`python <PROJECT-FOLDER>/inspectCode.py` in your terminal. The script will produce a file called *codeInspectOutput.md*. This file will contain all issues found in the entire solution.

#### Configuration
If the script produces irrelevant issues or otherwise unusable issues, you can add them to *ignoredIssues.csv*. Then they will be ignored when running the inspection script.

### Input system
The input system consists of a single instance (singleton) of the InputManager class. It handles all incoming touches on the screen and activates the game objects that are touched. 

#### Usage
To make the input system recognize and activate your game object, you need to make its class inherit from the class *Interactable*. Then you can implement the three virtual methods, *OnTouchBegin()*, *OnTouchHold()*, and *OnTouchReleased()*. 
Example: 
```clike=
public class Door : Interactable 
{
    public override void OnTouchBegin()
    {
        // Do something when the door is touched
     
    }
 
    public override void OnTouchHold()
    {
        // Do something while the door is being touched
        // Use variable timeHeld to know how long the touch has lasted
    }
 
    public override void OnTouchReleased()
    {
        // Do something when the touch on the door is released
    }    
}
```
### Event System
The Event Manager handles all the events. It has a dictionary of <int, UnityEvent> to store all the events and trigger them when needed. The int value is a ID converted by the Enum Name of the Event. The Eum EventName is in the EventManager script. When a new event is created, all the name into the enum and use (int)Event.Name to get the id of event. 

Whenever you have an event, register the event by calling EventManager.StartListening((int)EventName.Name, yourListener) to register your event. In addition, remember to stop listening when you don't need it anymore. When the condition of a certain event is achieved, invoke EventManager.TriggerEvent((int)Eventname.name) to start the event. 

Code Example: EventListenerExample.cs and EventTriggerExample 
