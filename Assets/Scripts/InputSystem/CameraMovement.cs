// Author: Itai Yavin

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
	[Tooltip("The minimum initial movement needed before any rotation happens. 0 = NO DEADZONE, 1 = NO MOVEMENT WILL BE ENOUGH")]
	[Range(0.0f, 1.0f)]
	public float deadZone = 0.1f;

	[Tooltip("The speed of which the camera will rotate")]
	[Range(0.1f, 5.0f)]
	public float speed = 1.0f;

	[Tooltip ("The minimum difference in movement read")]
	[Range(0.0f, 1.0f)]
	public float sensitivity = 0.05f;

	[Tooltip("The allowed movement range for the camera in X")]
	[Range(0.1f, 90.0f)]
	public float rotaryBoundsX = 30.0f;

	[Tooltip("The allowed movement range for the camera in Y")]
	[Range(0.1f, 90.0f)]
	public float rotaryBoundsY = 30.0f;

	private float currentDeviceRotationX, currentDeviceRotationY;
	private float minX, maxX, minY, maxY;

	private Vector2 calibratedDevicePosition = Vector2.zero;
	private Vector2 currentDirection = Vector2.zero;
	private Vector3 startRotation;

	void Awake () 
	{
		Input.gyro.enabled = true;

		EventManager.StartListening(EventName.CalibrateCameraGyroscope, Calibrate);

		startRotation = transform.rotation.eulerAngles;

		CalculateBounds();
	}
	
	void Update ()
	{
		UpdateDeviceRotationValues();

		UpdateTransformRotation();
	}

	private void UpdateTransformRotation()
	{
		Quaternion currentRotation = transform.rotation;

		float angleY = currentRotation.eulerAngles.y + (currentDirection.y * speed);
		float angleX = currentRotation.eulerAngles.x + (currentDirection.x * speed);

		angleY = AngleClamp(angleY, minY, maxY);
		angleX = AngleClamp(angleX, minX, maxX);
		
		Quaternion resultantRotation = Quaternion.AngleAxis(angleY, Vector3.up) * Quaternion.AngleAxis(angleX, Vector3.right);

		transform.rotation = resultantRotation;
	}

	private void UpdateDeviceRotationValues()
	{
		Vector2 calibratedInput = CalculateCalibratedRotationValues();
		float inputX = calibratedInput.x;
		float inputY = calibratedInput.y;


		if (inputX > deadZone || inputX < -deadZone)
		{
			currentDeviceRotationX = inputX;
		}
		else
		{
			currentDeviceRotationX = 0.0f;
		}

		if (inputY > deadZone || inputY < -deadZone)
		{
			currentDeviceRotationY = inputY;
		}
		else
		{
			currentDeviceRotationY = 0.0f;
		}

		UpdateDirection();
	}

	public void Calibrate()
	{
		calibratedDevicePosition.x = Input.gyro.attitude.x;
		calibratedDevicePosition.y = Input.gyro.attitude.y;
	}

	private Vector2 CalculateCalibratedRotationValues()
	{
		Vector2 calibratedInput;

		calibratedInput.x = calibratedDevicePosition.x - Input.gyro.attitude.x;
		calibratedInput.y = calibratedDevicePosition.y - Input.gyro.attitude.y;

		return calibratedInput;
	}

	private void UpdateDirection()
	{
		if (currentDeviceRotationX > 0.0f)
		{
			currentDirection.x = 1.0f;
		}
		else if (currentDeviceRotationX < 0.0f)
		{
			currentDirection.x = -1.0f;
		}
		else
		{
			currentDirection.x = 0.0f;
		}

		if (currentDeviceRotationY > 0.0f)
		{
			currentDirection.y = 1.0f;
		}
		else if (currentDeviceRotationY < 0.0f)
		{
			currentDirection.y = -1.0f;
		}
		else
		{
			currentDirection.y = 0.0f;
		}
	}

	private float AngleClamp(float value, float min, float max)
	{
		value = value > 180 ? value - 360 : value;

		value = Mathf.Clamp(value, min, max);

		return value;
	}

	private void CalculateBounds()
	{
		float startX = startRotation.x > 180 ? startRotation.x - 360 : startRotation.x;
		float startY = startRotation.y > 180 ? startRotation.y - 360 : startRotation.y;

		minX = startX - rotaryBoundsX;
		maxX = startX + rotaryBoundsX;

		minY = startY - rotaryBoundsY;
		maxY = startY + rotaryBoundsY;
	}
}