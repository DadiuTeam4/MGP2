using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaltNPepper : Interactable {

	public override void OnTouchBegin(Vector2 position)
	{
		AkSoundEngine.PostEvent ("Play_MGP2_SD_Herbs", gameObject);
	}
}
