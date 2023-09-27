using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeAI : MonoBehaviour
{
	private GameObject Player;

	// Start is called before the first frame update
	void Start()
    {
		Player = GameObject.FindGameObjectWithTag("PacMan");

	}
	public Vector2 OrangeTarget()
	{
		Ghost R = GetComponent<Ghost>();
		//refer to Ghost class
		Vector2 GoalPosition = Vector2.zero;
		//instantise the goal position of the orange ghost
		Vector2 PositionOfPlayer = Player.transform.localPosition;
		//find the current position of the player
		float length = Vector2.Distance(transform.localPosition, PositionOfPlayer);
		//using unitys vector2s distance formula find the local postion of the play and store it in length
	

		if (length > 8)
		//if the distance between the orange ghost and pacman is > than 8 then  =target pacman //same as red ghost
		{
			GoalPosition = new Vector2(Mathf.RoundToInt(PositionOfPlayer.x), Mathf.RoundToInt(PositionOfPlayer.y));
			//change the goal position to the specified point

		}
		else if (length < 8)
		{           //if pacmans distance is greater than 8 then orange will target the waypoint on the bottom left of the n=maze

			GoalPosition = R.ScatterWaypoint.transform.position;
		}

		return GoalPosition;
	}

	// Update is called once per frame
	void Update()
    {
        
    }
}
