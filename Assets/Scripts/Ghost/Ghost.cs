using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Ghost : MonoBehaviour {

	//this is the base class for ghosts
	//this essentially sets up the g
	public bool EnemyMovement = true;


	//eyes controller
	public Sprite ScaedStateEyesUp;
	public Sprite ScaredStateSpriteDown;
	public Sprite ScaredStateSpriteLeft;
	public Sprite ScaredStateSpriteRight;
	//house timers
	public float EnemyInHouseTimer = 0;//house timer set to0
	
	public int PinkinHouse = 6;
	public int BlueInHouse = 15;
	public int OrangeinHouse = 20;

	//speed of ghosts
	public float SpeedOFEnemy = 5.8f;
	public float RestartEnemySpeed = 5.8f;

	//scared
	public bool BLinkInScaredState = false;
	public int DurationOfScaredState = 10;//how long to stay in scaredstate
	public float ScaredStateSpeed = 2.7f;//scared state speed
	public float EatenSpeed = 10f;//eaten state speed
	public float ScaredTimer = 0;
	public int[] ScatterTimer = new[] { 7, 8, 9, 10 };//set up scatter timers for ghost
	public int[] ChaseTimer = new[] { 20, 21, 22, 23 };//setup chase timers for ghosts
	public int startBlinkingAt = 7;
	public GhostColor ghostType = GhostColor.Red;//
	public Vector2 Movement;//how ghosts move in this script
	public bool GhostHouseManipulator = true;//to contain ghosts within house
	public Waypoints OrignalWaypoint;//Ghosts orignal position
	public Waypoints ScatterWaypoint;//ghosts scatterwaypoint
	public Waypoints StartingGhostHouse;//orignal
	public Waypoints TemporaryWaypoint;//what waypoint the ghost is at
	public Waypoints LastWaypoint;//the last way
	public Waypoints GoalWaypoint;
	public int StateIncrementer = 1;//incrementer for state changes
	public EnemyStates StateOfGame = EnemyStates.Scatter;
	public EnemyStates LastStateOfGame;
	public float StateChangerTimer = 0;
	public float blinkTimer = 0;
	public float StoreMoveSpeed;//store speed for state change method
	public AudioSource GhostAudio;
	private GameObject Player;



	public enum EnemyStates {

		Chase,
		Scatter,
		Scared,
		Eaten
	}
	public enum GhostColor {

		Red,
		Pink,
		Blue,
		Orange
	}
	// Use this for initialization
	void Start () {

		GhostAudio = GameObject.Find ("Manager").transform.GetComponent<AudioSource> ();
		GetWaypointLocation Pos = GetComponent<GetWaypointLocation>();//refer to pacman class
		GhostDirectionDecision GDD = GetComponent<GhostDirectionDecision>();//instantise the 
		Player = GameObject.FindGameObjectWithTag ("PacMan");
		BoardSetUp Grid = GetComponent<BoardSetUp>();//refer to pacman class


		Waypoints Waypoint = Pos.WaypointLocation(transform.localPosition);




		if (Waypoint != null) {

			TemporaryWaypoint = Waypoint;
		}

		if (GhostHouseManipulator) {

			Movement = Vector2.up;
			GoalWaypoint =  TemporaryWaypoint.AdjacentWaypoints [0];

		} else {

			Movement = Vector2.left;
			GoalWaypoint = GDD.GhostDecisionMethod ();
		}

		LastWaypoint = TemporaryWaypoint;
		Ghostanimation R = GetComponent<Ghostanimation>();//refer to pacman class

		R.AnimateinRealTime();

	}





	// Update is called once per frame
	void Update () {
		MOVEFUNCTION Move = GetComponent<MOVEFUNCTION>();//refer to pacman class
		GhostStates States = GetComponent<GhostStates>();//refer to pacman class

		if (EnemyMovement) {
			
			States.ChangeStateOfGhosts ();

			Move.AllowGhostTomove ();


		}
	}


	public void MoveToStartingPosition()
	{

		//anyone besides blinky/red will be placed inside the hous
		if (transform.name != "Red")
			GhostHouseManipulator = true;

		//transform ghosts to orignalplace
		transform.position = OrignalWaypoint.transform.position;
		//if the ghosts are in the house
		if (GhostHouseManipulator)
		{
			Movement = Vector2.up;
		}
		else
		{
			Movement = Vector2.left;
		}
		Ghostanimation R = GetComponent<Ghostanimation>();//refer to pacman class

		R.AnimateinRealTime();
	}

	public	Vector2 GoalPositionOfGhost () {

		Vector2 GoalPosition = Vector2.zero;

        switch (ghostType)
        {
            case GhostColor.Red:
                {
                    RedAI RAI = GetComponent<RedAI>();//refer to RedAi class
                    GoalPosition = RAI.RedTarget();
                    Debug.Log("redtargettle" + GoalPosition);
                    break;
                }

            case GhostColor.Pink:
                {
                    PinkAI PAI = GetComponent<PinkAI>();//refer to PinkAi class
                    GoalPosition = PAI.PinkTarget();
                    Debug.Log("pink" + GoalPosition);
                    break;
                }

            case GhostColor.Blue:
                {
                    BlueAI BAI = GetComponent<BlueAI>();//refer to BlueAi class
                    GoalPosition = BAI.BlueTarget();
                    break;
                    Debug.Log("blue" + GoalPosition);

                }

            case GhostColor.Orange:
                {
                    OrangeAI OAI = GetComponent<OrangeAI>();//refer to OrangeAi class
                    GoalPosition = OAI.OrangeTarget();
                    break;
                    Debug.Log("orange" + GoalPosition);

                }
        }

        return GoalPosition;
	}




}

