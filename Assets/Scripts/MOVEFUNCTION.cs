using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOVEFUNCTION : MonoBehaviour
{


	public bool canMove = true;

	//public bool canMove = true;
	GameObject Player;
	GameObject Ghost;

	//public GameObject pacMan;
	// Start is called before the first frame update
	void Start()
	{
		Player = GameObject.FindGameObjectWithTag("PacMan");

	}
	public void AllowPlayerTomvove()
	{
		Player = GameObject.FindGameObjectWithTag("PacMan");

		Ghost = GameObject.FindGameObjectWithTag("Ghost");
		PacMan PLayer = GetComponent<PacMan>();//refer to pacman class
		Portal port = GetComponent<Portal>();//refer to pacman class
		Physicschecker phy = GetComponent<Physicschecker>();//refer to Physicschecker class

		//{
		if (PLayer.Waypointobjective != null)// if the Waypoint isnt nullt
		{

			if (PLayer.choosemovementposition == PLayer.movementposition * -1)
			{
				//Allow pacman to reverse directions
				PLayer.movementposition *= -1;

				Waypoints InWaypoint = PLayer.Waypointobjective;

				PLayer.Waypointobjective = PLayer.LastWaypoint;

				PLayer.LastWaypoint = InWaypoint;
			}

			if (phy.PlayerConstrictedWaypoint())
			{//restricts the players movmemenet so they stay within the confiness of the node
				PLayer.Waypoint = PLayer.Waypointobjective;

				transform.localPosition = PLayer.Waypoint.transform.position;

				GameObject Portalcomponent = port.PortalComponent(PLayer.Waypoint.transform.position);

				if (Portalcomponent != null)
				{
					//if the componnet is not null
					transform.localPosition = Portalcomponent.transform.position;
					//get the localposition of the portal component
					PLayer.Waypoint = Portalcomponent.GetComponent<Waypoints>();
				}

				Waypoints WaypointTransition = PLayer.pacmansablitytomove(PLayer.choosemovementposition);

				if (WaypointTransition != null)
					PLayer.movementposition = PLayer.choosemovementposition;
				//change the the pacmans movement position to his chosen direction
				if (WaypointTransition == null)
					WaypointTransition = PLayer.pacmansablitytomove(PLayer.movementposition);
				
				if (WaypointTransition != null)
				{

					PLayer.Waypointobjective = WaypointTransition;
					PLayer.LastWaypoint = PLayer.Waypoint;
					PLayer.Waypoint = null;

				}
				else
				{
					//stop movement
					PLayer.movementposition = Vector2.zero;
				}

			}
			else
			{

				transform.localPosition += (Vector3)(PLayer.movementposition * PLayer.PlayerMovement) * Time.deltaTime;
			}
		}
	}
	// Update is called once per frame
	//		PacMan refscript = GetComponent<PacMan>();//refer to pacman class


	//Movement class FOR GHOST
	public void AllowGhostTomove()
	{
		Ghost Gh = GetComponent<Ghost>();//refer to pacman class
		Portal port = GetComponent<Portal>();//refer to Portal class
		Physicschecker phy = GetComponent<Physicschecker>();//refer to Physicschecker class
		GhostDirectionDecision GDD = GetComponent<GhostDirectionDecision>();//refer to pacman class
																			//this class if to ensure that ghosts do not travel through the walls to reach pacman
																			//it is constrict the possible ways that they can move
																			//since it might use a n
		if (Gh.GoalWaypoint != Gh.TemporaryWaypoint)
		{//if the goats goal is not the current waypoint
			if
				(Gh.GoalWaypoint != null)
			{
				if (Gh.GhostHouseManipulator == false)
				{//this is initialisd as false in the ghost base class
					if (phy.GhostContrictedWAypoint())
					{//confide ghst movemnet

						Gh.TemporaryWaypoint = Gh.GoalWaypoint;
						//set ghosts current waypoint to their goal
						transform.localPosition = Gh.TemporaryWaypoint.transform.position;

						GameObject otherPortal = port.PortalComponent(Gh.TemporaryWaypoint.transform.position);

						if (otherPortal != null)
						{

							transform.localPosition = otherPortal.transform.position;
							//allow portal movement
							Gh.TemporaryWaypoint = otherPortal.GetComponent<Waypoints>();
						}

						Gh.GoalWaypoint = GDD.GhostDecisionMethod();
						//call the class that determines what goal waypoint the ghost will go for
						Gh.LastWaypoint = Gh.TemporaryWaypoint;
						//set the last waypoint to the current one
						Gh.TemporaryWaypoint = null;
						Ghostanimation f = GetComponent<Ghostanimation>();//refer to pacman class

						f.AnimateinRealTime();

					}
					else
					{

						transform.localPosition += (Vector3)Gh.Movement * Gh.SpeedOFEnemy * Time.deltaTime;
					}
				}
			}
		}
	}
}