using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaltNPepper : Interactable {

	public override void OnTouchBegin()
	{
		AkSoundEngine.PostEvent ("Play_MGP2_SD_Herbs", gameObject);
	}
}
