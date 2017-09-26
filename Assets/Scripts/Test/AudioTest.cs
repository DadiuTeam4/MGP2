	using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTest : MonoBehaviour {

	public float kitchenVolume; 
	public float livingroomVolume; 

	void Start () 
	{
		AkSoundEngine.PostEvent ("Ambience_kitchen", gameObject); 
		AkSoundEngine.PostEvent ("Ambience_livingroom", gameObject); 
		AkSoundEngine.SetRTPCValue ("Kitchen_volume", 0); 
		AkSoundEngine.SetRTPCValue ("Livingroom_volume", 100);
		AkSoundEngine.PostEvent ("Music", gameObject); 
	}
	
	void Update () 
	{
		if (Input.GetKey (KeyCode.A))
		{
			AkSoundEngine.SetRTPCValue ("Kitchen_volume", 100); 
			AkSoundEngine.SetRTPCValue ("Livingroom_volume", 0); 
		} 	
		if (Input.GetKey (KeyCode.S)) 
		{
			AkSoundEngine.SetRTPCValue ("Kitchen_volume", 0); 
			AkSoundEngine.SetRTPCValue ("Livingroom_volume", 100); 		
		}
		if(Input.GetKeyDown(KeyCode.Mouse0))
		{
			AkSoundEngine.PostEvent("OnScreenClick", gameObject); 
		}
		if (Input.GetKey (KeyCode.M)) 
		{
			AkSoundEngine.SetRTPCValue ("Music_volume", 100); 
		}
		if (Input.GetKey (KeyCode.N)) 
		{
			AkSoundEngine.SetRTPCValue ("Music_volume", 0); 
		}
	}
}

