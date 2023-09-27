using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostDirectionDecision : MonoBehaviour
{
	// Start is called before the first frame update
	void Start()
	{

	}


	public Waypoints GhostDecisionMethod()
	{//tomorrows job
		Ghost GH = GetComponent<Ghost>();//refer to pacman class
		Waypoints Availabletomove = null;//set initialiser

		Vector2 GoalPosition = Vector2.zero;//set goal position 

		Waypoints[] PossibleWaypoints = new Waypoints[4];//there are only a maximum of four possible directions, reference waypoint class to create arary of possible Waypoint
		Vector2[] VectorMovement = new Vector2[4];//this creates a vector 2 array fo all the possible directions available

		int Waypointincrementer = 0;

		switch (GH.StateOfGame)//if the current mode is Chase
		{
			case Ghost.EnemyStates.Chase:
				GoalPosition = GH.GoalPositionOfGhost(); //call the function that contains all the ghost ai

				break;
			case Ghost.EnemyStates.Scatter:
				GoalPosition = GH.ScatterWaypoint.transform.position;

				break;
			case Ghost.EnemyStates.Scared:
				GoalPosition = GetRandomBlockForFrightenedMode();
				//if the current mode is random then Pick a random Block in themaze
				break;
			case Ghost.EnemyStates.Eaten:
				//Return to ghosthouse if pacman has eaten ghost
				GoalPosition = GH.StartingGhostHouse.transform.position;

				break;
		}




		

      
		//loop over the ghosts current positions waypoint
		for (int i = 0; i < GH.TemporaryWaypoint.AdjacentWaypoints.Length; i++)
		{

			if (GH.TemporaryWaypoint.VectorLocation[i] != GH.Movement * -1)//Found a valid direction, second part of if statement is to ensure that ghosts are not allowed to reverse direction
			{

				if (GH.StateOfGame != Ghost.EnemyStates.Eaten)//Which would be state ghosts are in for most iterations of the game unless eaten by pacman
				{
					LocationOfBlock BlockCoord = GetComponent<LocationOfBlock>();//refer to location class to get Block at position.

					GameObject Block = BlockCoord.BlockLocation(GH.TemporaryWaypoint.transform.position);//get current Block

					if (Block.transform.GetComponent<Frame>().HouseEntarance == true)// if the ghost has found a waypoint that is the house enterance then do not allow for ghosts
						//to travel this way.
					{

						//these are the Waypoint above the ghost house 
						if (GH.TemporaryWaypoint.VectorLocation[i] != Vector2.down)//if ghosts location is just above the house, then allow movement anywhere besides vector down.
																									{
				
							//if the valid directions at the current state of the game doesnt equal down, allow that waypoint to be a  valid waypoint.
							PossibleWaypoints[Waypointincrementer] = GH.TemporaryWaypoint.AdjacentWaypoints[i];
							VectorMovement[Waypointincrementer] = GH.TemporaryWaypoint.VectorLocation[i];
							Waypointincrementer++;//increment inr value
						}


					}
					//if we arent in eaten mode which would be most of the game then allow movement
					//if the current state of the ghost isnt in eaten and its not a ghost house entarance allow regular movement
					else
					{

						PossibleWaypoints[Waypointincrementer] = GH.TemporaryWaypoint.AdjacentWaypoints[i];
						VectorMovement[Waypointincrementer] = GH.TemporaryWaypoint.VectorLocation[i];
						Waypointincrementer++;
					}

				}
				//if we are in eaten mode then allow ghost to travel movement inside the ghost house
				else
				{

					PossibleWaypoints[Waypointincrementer] = GH.TemporaryWaypoint.AdjacentWaypoints[i];
					VectorMovement[Waypointincrementer] = GH.TemporaryWaypoint.VectorLocation[i];
					Waypointincrementer++;
				}
			}
		}

		if (PossibleWaypoints.Length == 1)
		{
			//if we found one waypoint then set move to Waypoint to that
			Availabletomove = PossibleWaypoints[0];
			GH.Movement = VectorMovement[0];
		}

		if (PossibleWaypoints.Length > 1)
		{           //if we found more than one Waypoint then find Waypoint with shortest distance

			//set highlength to high number to ensure this loop runs
			float Highlenght = 5000f;

			for (int i = 0; i < PossibleWaypoints.Length; i++)

			{

				if (VectorMovement[i] != Vector2.zero) // if 
				{

					float length = Vector2.Distance(PossibleWaypoints[i].transform.position, GoalPosition);

					if (length < Highlenght)
					{
						//this loop will run continiously
						//least length will always be a high number
						//will iterate over all Waypoint that we can move to
						Highlenght = length;//set length to least length
						Availabletomove = PossibleWaypoints[i];// set move to Waypoint to the Waypoint found
						GH.Movement = VectorMovement[i];//set direction to found Waypoint
					}
				}
			}
		}

		return Availabletomove;
	}



	Vector2 GetRandomBlockForFrightenedMode()
	{
		//grid is 28x36
		//so allow ghosts to move ina  completly randonm direcition
		int x = Random.Range(0, 28);
		int y = Random.Range(0, 36);

		return new Vector2(x, y);
	}

	// Update is called once per frame
	void Update()
    {
        
    }
}
