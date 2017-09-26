using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
	[Tooltip("The allowed movement range for the camera in X")]
	[Range(0.1f, 90.0f)]
	public float rotaryBoundsX = 30.0f;

	[Tooltip("The allowed movement range for the camera in Y")]
	[Range(0.1f, 90.0f)]
	public float rotaryBoundsY = 30.0f;

	private Quaternion startRotation;
	private float minX, maxX, minY, maxY;
	private float currentDeviceRotationX = 0.0f, currentDeviceRotationY = 0.0f;

	private float lerpX = 0.5f;
	private float lerpY = 0.5f;

	private float[] movingAverageX = new float[5];
	private float[] movingAverageY = new float[5];

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

		float angleX, angleY;

		angleX = Mathf.Lerp(minX, maxX, lerpX);
		angleY = Mathf.Lerp(minY, maxY, lerpY);

		Quaternion resultantRotation = Quaternion.AngleAxis(angleY, Vector3.up) * Quaternion.AngleAxis(angleX, Vector3.right);
		transform.rotation = resultantRotation;
	}

	private void UpdateDeviceRotations()
	{
		float flippedX, flippedY;
		flippedX = Input.acceleration.y;
		flippedY = Input.acceleration.x;

		PushBack(flippedX, ref movingAverageX);
		PushBack(flippedY, ref movingAverageY);

		currentDeviceRotationX = CalculateMovingAverage(flippedX, movingAverageX);			
		currentDeviceRotationY = CalculateMovingAverage(flippedY, movingAverageY);
		
	}

	private float CalculateMovingAverage(float value, float[] array)
	{
		//array = PushBack(value, array);
		return Average(array);
	}

	private float Average(float[] array)
	{
		float sum = 0;
		for  (int i = 0; i < array.Length; i++)
		{
			sum += array[i];
		}

		return sum /= array.Length;
	}

	private float[] PushBack(float value, ref float[] array)
	{
		for (int i = array.Length-1; i > 0; i--)
		{
			array[i] = array[i - 1];
		}

		array[0] = value;

		SingleLinePrintArray(array);

		return array;
	}

	private float ClampValueForLerp(float x)
	{
		float result = 0;
		result = (x + 1) / 2;
		result = result > 1 ? 1 : result;

		return result;
	}

	private void SingleLinePrintArray<T>(T[] array)
	{
		string message = "";

		for (int i = 0; i < array.Length; i++)
		{
			message += " " + i + ": " + array[i];
		}

		Debug.Log(message);
	}
}