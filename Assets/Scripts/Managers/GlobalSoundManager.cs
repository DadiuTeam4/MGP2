using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalSoundManager : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		//Ambience
		AkSoundEngine.PostEvent ("Ambience_kitchen", gameObject); 
		AkSoundEngine.PostEvent ("Ambience_livingroom", gameObject); 
		//Ambience volume
		AkSoundEngine.SetRTPCValue ("Kitchen_volume", 0); 
		AkSoundEngine.SetRTPCValue ("Livingroom_volume", 100);
		//Music
		AkSoundEngine.PostEvent ("Music", gameObject); 
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
