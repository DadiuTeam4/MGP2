using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
	[Tooltip("The amount of movement needed before anything happens, at 0 the system is very sensible, at 1 no movement would be enough")]
	[Range(0.0f, 1.0f)]
	public float deadZone = 0.3f;

	[Tooltip("This scalar controls how fast the camera movement is")]
	[Range(0.1f, 5.0f)]
	public float speed = 0.5f;

	private Vector3 startPosition;
	private float currentDeviceRotationX, currentDeviceRotationY;

	void Awake () 
	{
		startPosition = transform.position;
	}
	
	void Update ()
	{
		UpdateDeviceRotations();
	
		UpdateRotation();
	}

	private void UpdateRotation()
	{
		float x = 0;
		float y = 0;
		if(currentDeviceRotationX > deadZone || currentDeviceRotationX < -deadZone)
		{
			y = currentDeviceRotationX;
		}
		
		if(currentDeviceRotationY > deadZone || currentDeviceRotationY < -deadZone)
		{
			x = currentDeviceRotationY;
		}

		transform.Rotate(x, y, 0.0f);
		Quaternion quaternionRotation = transform.rotation;
		transform.eulerAngles = new Vector3(quaternionRotation.eulerAngles.x, quaternionRotation.eulerAngles.y, 0.0f);
	}

	private void UpdateDeviceRotations()
	{
		currentDeviceRotationX = Input.acceleration.x;
		currentDeviceRotationY = Input.acceleration.y;
	}
}
