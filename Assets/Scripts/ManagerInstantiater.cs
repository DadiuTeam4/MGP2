using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerInstantiater : MonoBehaviour {
	public GameObject managerPrefab;

	void Awake () 
	{
		if(GameObject.FindWithTag("ManagerHolder") == null)
		{
			Instantiate(managerPrefab, Vector3.zero, Quaternion.identity);
		}	
	}
}
