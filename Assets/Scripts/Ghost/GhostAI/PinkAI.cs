using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkAI : MonoBehaviour
{

	private GameObject Player;

	// Start is called before the first frame update
	void Start()
    {
		Player = GameObject.FindGameObjectWithTag("PacMan");

	}
	public Vector2 PinkTarget()
	{

		
		//Four blocks ahead Pac-Man
		Vector2 PositionOfPlayer = Player.transform.localPosition;// pacManPosition
		Vector2 PacsMovementPosition = Player.GetComponent<PacMan>().MovementPosition;//pacManOrientation
		

		int PositionOfPlayerX = Mathf.RoundToInt(PositionOfPlayer.x);//pacManPositionX
		int PositionOfPlayery = Mathf.RoundToInt(PositionOfPlayer.y);//pacManPositionY

		Vector2 UsersBlock = new Vector2(PositionOfPlayerX, PositionOfPlayery);//pacManblock
	//	Debug.Log("Pacmans movementposition" + pacMan.GetComponent<PacMan>().MovementPosition);

		Vector2 GoalPosition = UsersBlock + (4 * PacsMovementPosition);//targetBlock


		return GoalPosition;
}

	// Update is called once per frame
	void Update()
    {
        
    }
}
