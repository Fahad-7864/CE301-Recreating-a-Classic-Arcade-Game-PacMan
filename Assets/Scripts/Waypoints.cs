using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Waypoints : MonoBehaviour {
	public Waypoints[] AdjacentWaypoints;
	public Vector2[] VectorLocation;

	// Use this for initialization
	void Start () {

		VectorLocation = new Vector2[AdjacentWaypoints.Length];
		Vectorposition();


	}

	void Vectorposition()
	{
		for (int i = 0; i < AdjacentWaypoints.Length; i++)
			//go through the adjacentwaypoint vector.
		{
			Waypoints waypoint = AdjacentWaypoints[i];
			//method to normalise vector to use on our grid
			//https://docs.unity3d.com/ScriptReference/Vector2.Normalize.html
			//this a method to calculate the available vectors that movement is allowed on
			//this essentially calculates the corresponding vectors that are adjacent to the waypoint
			//So if a waypoint has two adjacent waypoints
			//and one of them is a waypoint below
			//it will have avalue of -y
			//so a direction guide would be
			//-y=down
			//+y==up
			//-x=left
			//+x=right
			Vector2 Vectnormal = waypoint.transform.position - transform.position;
			//
			VectorLocation[i] = Vectnormal.normalized;
		}
	}
}