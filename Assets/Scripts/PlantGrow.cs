//Author: Jonathan
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantGrow : Interactable
{
	public float ScaleX = 1.0f;
	public float ScaleY = 1.0f;
	public float ScaleZ = 1.0f;
	public bool recalculateNormals = false;

	private Vector3[] baseVertices;

	
	void Update ()
	{
		if (timeHeld < 2)
		{
			ScalePlant();
		}
	}

	void ScalePlant()
	{ // DONT USE THIS SOLUTION. Scale the transform.scale instead.
		var mesher = GetComponent<MeshFilter>().mesh;
		if (baseVertices == null)
		{
			baseVertices = mesher.vertices;
		}
		var vertices = new Vector3[baseVertices.Length];
		for (var i = 0; i < vertices.Length; i++)
		{
			var vertex = baseVertices[i];
			vertex.x = vertex.x * ScaleX;
			vertex.x = vertex.y * ScaleY;
			vertex.x = vertex.z * ScaleZ;
			vertices[i] = vertex;
		}
		mesher.vertices = vertices;

	}
}
