using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Frame : MonoBehaviour {
	//class that helps determine if a pellet/waypoint is a certain type of object
	//called by all the waypoints gameobjects.
	public bool Eaten;
	public bool Portalwaypoint;
	public bool Pelletobject;
	public bool Powerpellet;
	public bool Ghosthouse;
	public GameObject Portalwaypointobject;
	public bool HouseEntarance;
}