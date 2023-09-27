using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pacmananimation : MonoBehaviour
{
	// Start is called before the first frame update

	GameObject Player;

	void Start()
    {
		Player = GameObject.FindGameObjectWithTag("PacMan");

	}

	public void TransformPacman()
	{
		
		Vector2 u = Vector2.up;
		Vector2 d = Vector2.down;
		Vector2 l = Vector2.left;
		Vector2 r = Vector2.right;

		PacMan pacmanscript = GetComponent<PacMan>();
		//refer to pacman class
		//https://docs.unity3d.com/ScriptReference/Transform-localScale.
		//https://docs.unity3d.com/ScriptReference/Transform-localRotation.html
		//https://docs.unity3d.com/ScriptReference/Transform-localEulerAngles.html
		if (pacmanscript.movementposition == u)
		{
			transform.localScale = new Vector3(1, 1, 1);
			transform.localRotation = Quaternion.Euler(0, 0, 90);
		}

		else if (pacmanscript.movementposition == d)
		{
			//transform pacman down using localrotation
			transform.localScale = new Vector3(1, 1, 1);
			transform.localRotation = Quaternion.Euler(0, 0, 270);
		}
	
		else if (pacmanscript.movementposition == r)
		{

			transform.localScale = new Vector3(1, 1, 1);
			transform.localRotation = Quaternion.Euler(0, 0, 0);

		}
		if (pacmanscript.movementposition == l)
		{

			transform.localScale = new Vector3(-1, 1, 1);
			transform.localRotation = Quaternion.Euler(0, 0, 0);

		}

	}

	public void UpdateAnimationState()
	{
		PacMan pacmanscript = GetComponent<PacMan>();//refer to pacman class

		//if pacmans direction is nothing 
		//stop animation
		//otherwise carry on
		Vector2 still = Vector2.zero;
		if (pacmanscript.movementposition == still)
		{

			GetComponent<Animator>().enabled = false;
			GetComponent<SpriteRenderer>().sprite = pacmanscript.PacmanNotMovingSprite;

		}
		else
		{

			GetComponent<Animator>().enabled = true;
		}
	}

	// Update is called once per frame
	void Update()
    {
		PacMan pacmanscript = GetComponent<PacMan>();//refer to pacman class

		if (pacmanscript.PlayerIsAbleToMove)
		{


			TransformPacman();
			UpdateAnimationState();


		}
	;
	}
}
