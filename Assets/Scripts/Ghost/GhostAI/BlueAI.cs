using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueAI : MonoBehaviour
{
	private GameObject Player;

	// Start is called before the first frame update
	void Start()
    {
		Player = GameObject.FindGameObjectWithTag("PacMan");

	}
	public Vector2 BlueTarget()
	{

		//find the position of the red ghst
		Vector2 RedGhostsCurrentPosition = GameObject.Find("Red").transform.localPosition;
		int RedGhostCurrentPositonX = Mathf.RoundToInt(RedGhostsCurrentPosition.x);
		int RedGhostCurrentPositionY = Mathf.RoundToInt(RedGhostsCurrentPosition.y);
		RedGhostsCurrentPosition = new Vector2(RedGhostCurrentPositonX, RedGhostCurrentPositionY);
		//find the posiiton of the player
		Vector2 PositionOfPlayer = Player.transform.localPosition;
		//call the movement position method in pacman
		Vector2 PacsMovementPosition = Player.GetComponent<PacMan>().MovementPosition;
		//find the position x and y of player
		int PositionOfPlayerX = Mathf.RoundToInt(PositionOfPlayer.x);
		int PositionOfPlayerY = Mathf.RoundToInt(PositionOfPlayer.y);
		//players current Block
		Vector2 UsersBlock = new Vector2(PositionOfPlayerX, PositionOfPlayerY);
		//so position x and y of player + double the movement posotion of pacman
		Vector2 GoalPosition = UsersBlock + (2 * PacsMovementPosition);
		
		//get the distance between reds current Block and the goal position
		float length = Vector2.Distance(RedGhostsCurrentPosition, GoalPosition);
		length *= 2;
		//double the the variable
		GoalPosition = new Vector2(RedGhostsCurrentPosition.x + length, RedGhostsCurrentPosition.y + length);
		//add blinkys current position to the x,y to the lenght variable, do this for both x and y
		//this makes blinkys artificial inteligence quite sporadic as he his formula for finding the target will be unique compared to the other ai
		return GoalPosition;
	}

	// Update is called once per frame
	void Update()
    {
        
    }
}
