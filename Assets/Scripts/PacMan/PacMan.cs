using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PacMan : MonoBehaviour {

	public RuntimeAnimatorController Eatanim;

	public RuntimeAnimatorController PlayerDeathAnim;
	public GameObject Player;

	public float PlayerMovement = 6.0f;
	public Sprite PacmanNotMovingSprite;
	public Waypoints Waypoint;
	public Waypoints LastWaypoint;
	public Waypoints Waypointobjective;
	public bool PlayerIsAbleToMove = true;
	public Vector2 movementposition = Vector2.zero;
	public Vector2 choosemovementposition;
	
	public Waypoints InitialPositionOfUser;


	// Use this for initialization
	void Start () {
		GetWaypointLocation Coord = GetComponent<GetWaypointLocation>();//refer to pacman class
		BoardSetUp gr = GetComponent<BoardSetUp>();//refer to pacman class
		//Locat
		Waypoints Waypont = Coord.WaypointLocation(transform.localPosition);

		Player = GameObject.FindGameObjectWithTag("PacMan");
		InitialPositionOfUser = Waypont;
		//if the waypoint the player is currently in is not null
		//then set the starting position of the user to the waypoint
		if (Waypont != null)
		{

			Waypoint = Waypont;

		}

	


		movementposition = Vector2.right;

		MoveLocationOfpac(movementposition);
	}

	public Vector2 MovementPosition   // property
	{
		get { return movementposition; }   // get method
	}


	public void MoveToStartingPosition () {

		transform.position = InitialPositionOfUser.transform.position;
		movementposition = Vector2.left;
		transform.GetComponent<SpriteRenderer> ().sprite = PacmanNotMovingSprite;

		pacmananimation refscript = GetComponent<pacmananimation>();//refer to pacmananimation

		refscript.TransformPacman();
	}



	




	public Waypoints pacmansablitytomove(Vector2 Movement)
	{
		//set waypoint up
		Waypoints cWaypointDirection = null;

		for (int i = 0; i < Waypoint.AdjacentWaypoints.Length; i++)
		{
			//loop through the array in waypoint
			if (Waypoint.VectorLocation[i] == Movement)
			{
				//if the user picks a movement position the vector graph, x,y
				//and it
				cWaypointDirection = Waypoint.AdjacentWaypoints[i];
				//add the initialiser to the array of waypoints
				break;
			}
		}
		//return initialiser.
		return cWaypointDirection;
	}





	public void MoveLocationOfpac(Vector2 Movement)
	{
		//if the initilaiser is not equal to the pacmans choice
		if (Movement != movementposition)
			choosemovementposition = Movement;
		//if waypoint is not noll
		if (Waypoint != null)
		{
			//if the waypoint isnt null
			Waypoints WaypointDirection = pacmansablitytomove(Movement);
			//create initiali
			if (WaypointDirection != null)
			{
				//if the position of direction is null
				//set initlaier to pacman
				movementposition = Movement;
				LastWaypoint = Waypoint;

				Waypointobjective = WaypointDirection;
				Waypoint = null;
			}
		}
	}








	// Update is called once per frame
	void Update () {
		MOVEFUNCTION refscript = GetComponent<MOVEFUNCTION>();//refer to pacman class

		if (PlayerIsAbleToMove) {
			//Movementcontroller();


			refscript.AllowPlayerTomvove ();

		

		}
	}




	

}
