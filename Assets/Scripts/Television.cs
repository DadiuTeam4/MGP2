using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Television : Interactable {

	public override void OnTouchBegin()
	{
		AkSoundEngine.PostEvent ("Play_MGP2_SD_Television", gameObject); 
	}
}
