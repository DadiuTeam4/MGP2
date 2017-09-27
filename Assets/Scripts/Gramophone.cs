using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gramophone : Interactable {

	// Use this for initialization

	public override void OnTouchBegin()
	{	
		AkSoundEngine.PostEvent ("Play_MGP2_SD_Vinyl", gameObject); 
	}

}

	