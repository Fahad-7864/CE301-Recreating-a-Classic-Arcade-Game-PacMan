using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Releaseghost : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

	void GhostControllerwhenghostisineatenstate()
	{

		Ghost GH = GetComponent<Ghost>();//reference to Ghost class
		LocationOfBlock BlockPos = GetComponent<LocationOfBlock>();//reference to pacman eat class
		GetWaypointLocation Waycoord = GetComponent<GetWaypointLocation>();//reference waypointlocation class
		if (GH.StateOfGame == Ghost.EnemyStates.Eaten)
		{//if the state of game of is in eaten 

			GameObject Block = BlockPos.BlockLocation(transform.position);
			//get the blocklocation
			if (Block != null)
			{

				if (Block.transform.GetComponent<Frame>() != null)
				{
					//check to see the boolean value of that block location

					if (Block.transform.GetComponent<Frame>().Ghosthouse)
					{
						//if the block you got is a ghosthouse
						//return the speed of the eaten ghost 
						//to basic speed
						GH.SpeedOFEnemy = GH.RestartEnemySpeed;

						Waypoints Waypoint = Waycoord.WaypointLocation(transform.position);

						if (Waypoint != null)
						{
							//onlyallow eaten ghost to travelup
							GH.TemporaryWaypoint = Waypoint;

							GH.Movement = Vector2.up;
							GH.GoalWaypoint = GH.TemporaryWaypoint.AdjacentWaypoints[0];
							GH.LastWaypoint = GH.TemporaryWaypoint;
							//swittch state to chase
							GH.StateOfGame = Ghost.EnemyStates.Chase;
							Ghostanimation f = GetComponent<Ghostanimation>();//refer to animation class
							//change ghost animation to normal
							f.AnimateinRealTime();
						}
					}
				}
			}
		}
	}

	
	void ReleasePinkGhost()
	{
		//this is to check if the ghost is a specific color and is currently
		//in the ghost house
		//if these components are true
		//then set the boolean value to false
		//to allow movememnt of ghosts.
		Ghost Gh = GetComponent<Ghost>();//refer to Ghost class

		if (Gh.ghostType == Ghost.GhostColor.Pink && Gh.GhostHouseManipulator)
		{

			Gh.GhostHouseManipulator = false;
		}
	}

	void ReleaseBlueGhost()
	{
		//this is to check if the ghost is a specific color and is currently
		//in the ghost house
		//if these components are true
		//then set the boolean value to false
		//to allow movememnt of ghosts.
		Ghost R = GetComponent<Ghost>();//refer to Ghost class

		if (R.ghostType == Ghost.GhostColor.Blue && R.GhostHouseManipulator)
		{

			R.GhostHouseManipulator = false;
		}
	}

	void ReleaseOrangeGhost()
	{
		//this is to check if the ghost is a specific color and is currently
		//in the ghost house
		//if these components are true
		//then set the boolean value to false
		//to allow movememnt of ghosts.
		Ghost R = GetComponent<Ghost>();//refer to Ghost class

		if (R.ghostType == Ghost.GhostColor.Orange && R.GhostHouseManipulator)
		{

			R.GhostHouseManipulator = false;
		}
	}

	void ReleaseGhosts()
	{
		Ghost Gh = GetComponent<Ghost>();//refer to Ghost class

		Gh.EnemyInHouseTimer += Time.deltaTime;

		if (Gh.EnemyInHouseTimer > Gh.PinkinHouse)
			ReleasePinkGhost();

		if (Gh.EnemyInHouseTimer > Gh.BlueInHouse)
			ReleaseBlueGhost();

		if (Gh.EnemyInHouseTimer > Gh.OrangeinHouse)
			ReleaseOrangeGhost();
	}
	// Update is called once per frame
	void Update()
	{
		Ghost R = GetComponent<Ghost>();//refer to pacman class
		//if ghost is able tomove
		//call functions
		if (R.EnemyMovement)
		{
			ReleaseGhosts();
			GhostControllerwhenghostisineatenstate();
		}
	}
}
