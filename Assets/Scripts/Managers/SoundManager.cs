using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
	public void PostEvent(string soundName, GameObject soundPlayingObject)
	{
		AkSoundEngine.PostEvent(soundName, soundPlayingObject);
	}

	public void SetRTPCValue(string soundName, int value)
	{
		AkSoundEngine.SetRTPCValue(soundName, value);
	}

}