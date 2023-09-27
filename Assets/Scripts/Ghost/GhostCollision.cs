using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GhostCollision : MonoBehaviour
{
	// Start is called before the first frame update
	private GameObject pacMan;
	public void CheckCollision()
	{
		Ghost GH = GetComponent<Ghost>();//refer to Ghost class

		//https://docs.unity3d.com/ScriptReference/Rect.html
		Rect BoundingBoxForPacMan = new Rect(pacMan.transform.position, pacMan.transform.GetComponent<SpriteRenderer>().sprite.bounds.size / 4);
		Rect BoundingBoxForEnemy = new Rect(transform.position, transform.GetComponent<SpriteRenderer>().sprite.bounds.size / 4);

		if (BoundingBoxForEnemy.Overlaps(BoundingBoxForPacMan))//if the Ghost sprites overlaps pacmans

		{
			if (GH.StateOfGame == Ghost.EnemyStates.Scared)
				//if the current state of the ghosts is in frightened then pacman will eat the ghosts
			{
				EnemyEaten();
			}
			else
			{
				if (GH.StateOfGame != Ghost.EnemyStates.Eaten)
				{//if the current state of the game is anyhthing but eaten(normal state of the game) then Start the function to proess pacmans death
					GameObject.Find("Manager").transform.GetComponent<Death>().Stage1Death();
				}
			}
		}
	}

public 	void EnemyEaten()
	{

		//this method is for defining the eaten state of the ghost
		//when pacman eats a ghost this script will be called by check collision
		Ghost Gh = GetComponent<Ghost>();//refer to pacman class
		Ghostanimation Animator = GetComponent<Ghostanimation>();//refer to pacman class
		GameObject.Find("Manager").transform.GetComponent<GhostCollision>().DisplayEnemyeatenscore(this.GetComponent<Ghost>());

		Gh.StateOfGame = Ghost.EnemyStates.Eaten;
		Gh.StoreMoveSpeed = Gh.SpeedOFEnemy;
		Gh.SpeedOFEnemy = Gh.EatenSpeed;
		Animator.AnimateinRealTime();


		if (Menu.GameActive)
		{
			BoardSetUp.playerOneScore += BoardSetUp.EnemyEatenConsecutiveScore;


		}
		
		
		

		BoardSetUp.EnemyEatenConsecutiveScore = BoardSetUp.EnemyEatenConsecutiveScore * 2;

	}


	public void DisplayEnemyeatenscore(Ghost EnemyEaten)//done
	{
		BoardSetUp GR = GetComponent<BoardSetUp>();//refer to pacman class
		GameObject pacMan = GameObject.Find("PacMan");
		if (GR.isobjecteaten==false)
		{
			GR.isobjecteaten = true;
			//world coordinate space
			Vector2 Coord = EnemyEaten.transform.position;//get location of the eaten ghost
		  //Convert the game position of the eaten ghost to the canvas position as they are seperate.
		//LINK.https://docs.unity3d.com/2017.4/Documentation/ScriptReference/Camera.WorldToViewportPoint.html	
		Vector2 Canvasposition = Camera.main.WorldToViewportPoint(Coord);
			//link.https://docs.unity3d.com/ScriptReference/RectTransform.html
			GR.EnemyEatenScoreText.GetComponent<RectTransform>().anchorMin = Canvasposition;
			GR.EnemyEatenScoreText.GetComponent<RectTransform>().anchorMax =(Canvasposition);

			//Disable sprite for enemy
			EnemyEaten.transform.GetComponent<SpriteRenderer>().enabled = false;
			
			
			//set the score text to appear in the center of where the ghost was eatem
			GR.EnemyEatenScoreText.text = BoardSetUp.EnemyEatenConsecutiveScore.ToString();
			GR.EnemyEatenScoreText.GetComponent<Text>().enabled = true;
			//Stop movement of all enemies.
			GameObject[] i = GameObject.FindGameObjectsWithTag("Ghost");

			foreach (GameObject Enemy in i)//find each ghost in array
			{
				Enemy.transform.GetComponent<Ghost>().EnemyMovement = false;
			}
			// Stop background Music
			transform.GetComponent<AudioSource>().Stop();
			//Play the eaten sound
			transform.GetComponent<AudioSource>().PlayOneShot(GR.GhostEaten);
			//disable the pacman sprite once a ghost has been eaten
			//stop pacmans movement as soon as a ghost has been eaten
			pacMan.transform.GetComponent<PacMan>().PlayerIsAbleToMove = false;
			pacMan.transform.GetComponent<SpriteRenderer>().enabled = false;

			StartCoroutine(ResumeGameaftereatenstate(0.70f, EnemyEaten));
		}
	}

	IEnumerator ResumeGameaftereatenstate(float delay, Ghost EnemyEaten)//enemyeaten is the ghost that will be passed into this function
	{
		//this function hides everything that we displayed Displayenemyeatenscore
		BoardSetUp Grid = GetComponent<BoardSetUp>();//refer to Gameboard class

		yield return new WaitForSeconds(delay);

		//Hide the score previously displayed
		Grid.EnemyEatenScoreText.GetComponent<Text>().enabled = false;
		//continue all enemy movement
		EnemyEaten.transform.GetComponent<SpriteRenderer>().enabled = true;
		GameObject[] i = GameObject.FindGameObjectsWithTag("Ghost");//find each ghost in array
		foreach (GameObject Enemy in i)
		{
			Enemy.transform.GetComponent<Ghost>().EnemyMovement = true;
		}
		//Show pacman and allow user to move around
		GameObject pacMan = GameObject.Find("PacMan");
		pacMan.transform.GetComponent<PacMan>().PlayerIsAbleToMove = true;
		pacMan.transform.GetComponent<SpriteRenderer>().enabled = true;
		//Start Background Music
		transform.GetComponent<AudioSource>().Play();
		Grid.isobjecteaten = false;
	}


	void Start()

    {

		pacMan = GameObject.FindGameObjectWithTag("PacMan");

	}

	// Update is called once per frame
	void Update()
    {
		CheckCollision();
    }
}
