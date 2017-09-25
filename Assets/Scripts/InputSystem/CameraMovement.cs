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
	[Range(0.1f, 5.0f)]
	public float boundsX = 1.0f;

	[Tooltip("The allowed movement range for the camera in Y")]
	[Range(0.1f, 5.0f)]
	public float boundsY = 1.0f;

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
		if (transform.rotation.x > -boundsX && transform.rotation.x < boundsX)
		{
			if (currentDeviceRotationX > deadZone || currentDeviceRotationX < -deadZone)
			{
				x = currentDeviceRotationX;
			}
		}
		
		if (transform.rotation.y > -boundsY && transform.rotation.y < boundsY)
		{
			if (currentDeviceRotationY > deadZone || currentDeviceRotationY < -deadZone)
			{
				y = currentDeviceRotationY;
			}
		}

		Quaternion resultantRotation = Quaternion.AngleAxis(y * speed, Vector3.up) * Quaternion.AngleAxis(x * speed, Vector3.right);
		transform.rotation = resultantRotation;
	}

	private void UpdateDeviceRotations()
	{
		currentDeviceRotationX = Input.acceleration.y;
		currentDeviceRotationY = Input.acceleration.x;
	}
}
