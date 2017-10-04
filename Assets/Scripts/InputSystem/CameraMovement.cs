// Author: Itai Yavin

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour 
{
	public GyroscopeState gyroscopeState;

	[Tooltip("The minimum initial movement needed before any rotation happens. 0 = NO DEADZONE, 1 = NO MOVEMENT WILL BE ENOUGH")]
	[Range(0.0f, 5.0f)]
	public float deadZone = 1.0f;

	[Tooltip("The speed of which the camera will rotate")]
	[Range(0.01f, 2.0f)]
	public float speed = 0.2f;

	[Tooltip ("The minimum difference in movement read")]
	[Range(0.0f, 1.0f)]
	public float sensitivity = 0.05f;

	[Tooltip ("Inverse device direction in X and Y")]
	public bool inverseX = true, inverseY = true;

	[Header("Rotation Settings")]
	[Tooltip("The allowed movement range for the camera in X, for rotation")]
	[Range(0.0f, 10.0f)]
	public float rotaryBoundsX = 1.0f;

	[Tooltip("The allowed movement range for the camera in Y, for rotation")]
	[Range(0.0f, 10.0f)]
	public float rotaryBoundsY = 1.0f;

	[Header("Panning Settings")]
	[Tooltip("The allowed movement range for camera in X, for panning")]
	[Range(0.0f, 20.0f)]
	public float panningBoundsX = 1.0f;
	
	[Tooltip("The allowed movement range for camera in Y, for panning")]
	[Range(0.0f, 20.0f)]
	public float panningBoundsY = 1.0f;

	private float currentDeviceRotationX, currentDeviceRotationY;
	private float rotationMinimumX, rotationMaximumX, rotationMinimumY, rotationMaximumY;
	private float panningMinimumX, panningMaximumX, panningMinimumY, panningMaximumY;

	private Vector2 currentDirection = Vector2.zero;
	private Vector3 startRotation;
	private Vector3 startPosition;

	void Awake () 
	{
		EventManager.StartListening(EventName.InverseCameraGyroScopeX, InverseX);
		EventManager.StartListening(EventName.InverseCameraGyroScopeY, InverseY);

		Input.gyro.enabled = true;

		startRotation = transform.rotation.eulerAngles;
		startPosition = transform.position;

		CalculateRotationBounds();
		CalculatePanningBounds();
	}
	
	void Update ()
	{
		UpdateDeviceRotationValues();

		if (gyroscopeState.Equals(GyroscopeState.Rotating))
		{
			UpdateTransformRotation();
		}
		else
		{
			UpdateTransformLocation();
		}
	}

	private void InverseX()
	{
		inverseX = !inverseX;
	}

	private void InverseY()
	{
		inverseY = !inverseY;
	}

	private void UpdateTransformLocation()
	{
		Vector3 currentPosition = transform.position;
		float positionX = currentPosition.x + (currentDirection.y * speed);
		float positionY = currentPosition.y + (currentDirection.x * speed);

		positionX = Mathf.Clamp(positionX, panningMinimumX, panningMaximumX);
		positionY = Mathf.Clamp(positionY, panningMinimumY, panningMaximumY);

		transform.position = new Vector3(positionX, positionY, transform.position.z);
	}

	private void UpdateTransformRotation()
	{
		Quaternion currentRotation = transform.rotation;

		float angleY = currentRotation.eulerAngles.y + (currentDirection.y * speed);
		float angleX = currentRotation.eulerAngles.x + (currentDirection.x * speed);

		angleY = AngleClamp(angleY, rotationMinimumY, rotationMaximumY);
		angleX = AngleClamp(angleX, rotationMinimumX, rotationMaximumX);
		
		Quaternion resultantRotation = Quaternion.AngleAxis(angleY, Vector3.up) * Quaternion.AngleAxis(angleX, Vector3.right);

		transform.rotation = resultantRotation;
	}

	private void UpdateDeviceRotationValues()
	{
		Vector2 gyroScopeInput = GetRotationValues();
		float inputX = gyroScopeInput.x;
		float inputY = gyroScopeInput.y;

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

	private Vector2 GetRotationValues()
	{
		Vector2 gyroScopeInput;

		gyroScopeInput.x = Input.gyro.rotationRateUnbiased.x;
		gyroScopeInput.y = Input.gyro.rotationRateUnbiased.y;

		return gyroScopeInput;
	}

	private void UpdateDirection()
	{
		if (currentDeviceRotationX > 0.0f)
		{
			currentDirection.x = inverseX ? 1.0f : -1.0f;
		}
		else if (currentDeviceRotationX < 0.0f)
		{
			currentDirection.x = inverseX ? -1.0f : 1.0f;
		}
		else
		{
			currentDirection.x = 0.0f;
		}

		if (currentDeviceRotationY > 0.0f)
		{
			currentDirection.y = inverseY ? 1.0f : -1.0f;
		}
		else if (currentDeviceRotationY < 0.0f)
		{
			currentDirection.y = inverseY ? -1.0f : 1.0f;
		}
		else
		{
			currentDirection.y = 0.0f;
		}
	}

	private float AngleClamp(float value, float minimum, float maximum)
	{
		value = value > 180 ? value - 360 : value;

		value = Mathf.Clamp(value, minimum, maximum);

		return value;
	}

	private void CalculatePanningBounds()
	{
		panningMinimumX = startPosition.x - panningBoundsX;
		panningMaximumX = startPosition.x + panningBoundsX;
		
		panningMinimumY = startPosition.y - panningBoundsY;
		panningMaximumY = startPosition.y + panningBoundsY;
	}

	private void CalculateRotationBounds()
	{
		float startX = startRotation.x > 180 ? startRotation.x - 360 : startRotation.x;
		float startY = startRotation.y > 180 ? startRotation.y - 360 : startRotation.y;

		rotationMinimumX = startX - rotaryBoundsX;
		rotationMaximumX = startX + rotaryBoundsX;

		rotationMinimumY = startY - rotaryBoundsY;
		rotationMaximumY = startY + rotaryBoundsY;
	}

	public enum GyroscopeState
	{
		Rotating,
		Panning
	}
}