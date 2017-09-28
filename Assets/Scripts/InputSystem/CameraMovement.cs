﻿// Author: Itai Yavin

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

	private Vector3 startRotation;
	private float minX, maxX, minY, maxY;
	private float currentDeviceRotationX, currentDeviceRotationY;

	private float lerpX = 0.5f;
	private float lerpY = 0.5f;

	private float[] movingAverageX = new float[5];
	private float[] movingAverageY = new float[5];

	void Awake () 
	{
		startRotation = transform.rotation.eulerAngles;

		minX = startRotation.x - rotaryBoundsX;
		maxX = startRotation.x + rotaryBoundsX;

		minY = startRotation.y - rotaryBoundsY;
		maxY = startRotation.y + rotaryBoundsY;

	}
	
	void Update ()
	{
		UpdateDeviceRotationValues();

		UpdateTransformRotation();
	}

	private void UpdateTransformRotation()
	{
		lerpX = ClampValueForLerp(currentDeviceRotationX);
		lerpY = ClampValueForLerp(currentDeviceRotationY);

		float angleX = Mathf.Lerp(minX, maxX, lerpX);
		float angleY = Mathf.Lerp(minY, maxY, lerpY);

		Quaternion resultantRotation = Quaternion.AngleAxis(angleY, Vector3.up) * Quaternion.AngleAxis(angleX, Vector3.right);
		transform.rotation = resultantRotation;
	}

	private void UpdateDeviceRotationValues()
	{
		float flippedX = Input.acceleration.y;
		float flippedY = Input.acceleration.x;

		currentDeviceRotationX = CalculateMovingAverage(flippedX, ref movingAverageX);			
		currentDeviceRotationY = CalculateMovingAverage(flippedY, ref movingAverageY);
		
	}

	private float CalculateMovingAverage(float value, ref float[] array)
	{
		array = PushBack(value, array);
		return Average(array);
	}

	private float Average(float[] array)
	{
		float sum = 0;
		foreach (float element in array)
		{
			sum += element;
		}
		
		sum /= array.Length;

		return sum;
	}

	private float[] PushBack(float pushedBackValue, float[] array)
	{
		for (int i = array.Length-1; i > 0; i--)
		{
			array[i] = array[i - 1];
		}

		array[0] = pushedBackValue;

		return array;
	}

	private float ClampValueForLerp(float x)
	{
		float result = (x + 1) / 2;
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