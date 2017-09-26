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

	[Tooltip("The allowed movement range for the camera in X")]
	[Range(0.1f, 90.0f)]
	public float rotaryBoundsX = 30.0f;

	[Tooltip("The allowed movement range for the camera in Y")]
	[Range(0.1f, 5.0f)]
	public float rotaryBoundsY = 30.0f;

	private Quaternion startRotation;
	private float minX, maxX, minY, maxY;
	private float currentDeviceRotationX, currentDeviceRotationY;
	private float previousValidDeviceRotationX, previousValidDeviceRotationY;

	private float lerpX = 0.5f;
	private float lerpY = 0.5f;

	void Awake () 
	{
		startRotation = transform.rotation;

		minX = startRotation.x - rotaryBoundsX;
		maxX = startRotation.x + rotaryBoundsX;

		minY = startRotation.y - rotaryBoundsY;
		maxY = startRotation.y + rotaryBoundsY;
	}
	
	void Update ()
	{
		UpdateDeviceRotations();
	
		UpdateRotation();
	}

	private void UpdateRotation()
	{
		lerpX = ClampValueForLerp(currentDeviceRotationX);
		lerpY = ClampValueForLerp(currentDeviceRotationY);

		
		
	}

	private void UpdateDeviceRotations()
	{
		currentDeviceRotationX = Input.acceleration.y;
		currentDeviceRotationY = Input.acceleration.x;
	}

	private float ClampValueForLerp(float x)
	{
		float result = 0;
		result = (x + 1) / 2;
		result = result > 1 ? 1 : result;

		return result;
	}
}


/*
		float x = 0;
		float y = 0;

		if (currentDeviceRotationX > deadZone || currentDeviceRotationX < -deadZone)
		{
			x = currentDeviceRotationX;
		}
		
		if (currentDeviceRotationY > deadZone || currentDeviceRotationY < -deadZone)
		{
			y = currentDeviceRotationY;
		}

		Quaternion resultantRotation = Quaternion.AngleAxis(y, Vector3.up) * Quaternion.AngleAxis(x, Vector3.right);
		transform.rotation = resultantRotation;
		*/