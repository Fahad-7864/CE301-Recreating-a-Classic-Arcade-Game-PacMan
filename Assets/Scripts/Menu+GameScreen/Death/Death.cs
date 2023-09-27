using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Death : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
	public void Stage1Death()
		//this is the the function that gets called by the collision method
		//Stage 1
	{//this class gets called by check collison which is assigned to the ghost game 
		BoardSetUp Grid = GetComponent<BoardSetUp>();//refer to Board class

		if (Grid.isObjectDead==false) //if the state of the game is not in false.
		{
			//stops allcoroutines
			StopAllCoroutines();
			//if player is alive
			if (Menu.GameActive)
			{

				Grid.PlayerGame.GetComponent<Text>().enabled = true;
			}
		
			Grid.isObjectDead = true;

			GameObject[] i = GameObject.FindGameObjectsWithTag("Ghost");
			//find every enemy and stop its movement
			foreach (GameObject enemy in i)
			{

				enemy.transform.GetComponent<Ghost>().EnemyMovement = false;
			}
			//stop players movement
			GameObject Player = GameObject.Find("PacMan");
			Player.transform.GetComponent<PacMan>().PlayerIsAbleToMove = false;
			Player.transform.GetComponent<Animator>().enabled = false;
			//stop audio
			transform.GetComponent<AudioSource>().Stop();

			StartCoroutine(Stage2Death(2));
		}
	}

	IEnumerator Stage2Death(float Time)
	{//This class gets called by StartDeath
		//this is stage 2 of death
		yield return new WaitForSeconds(Time);
		//this suspends any coroutines for a specified duration

		GameObject[] i = GameObject.FindGameObjectsWithTag("Ghost");
		//finds Any objects with Tag
		//disable the ghost sprites
		foreach (GameObject enemy in i)//iterates every enemy object 
		{

			enemy.transform.GetComponent<SpriteRenderer>().enabled = false;
		}

		StartCoroutine(Stage3Death(0.9f));
	}

	IEnumerator Stage3Death(float Time)
	{//this is stage 3
		
		BoardSetUp Grid = GetComponent<BoardSetUp>();//refer to pacman class
		//find the players position
		GameObject Player = GameObject.Find("PacMan");
		//maybe change
		//https://docs.unity3d.com/ScriptReference/Transform-localScale.html
		//find pacman and transform its local scale and rotation so animation does not look clunky
		//https://docs.unity3d.com/ScriptReference/Quaternion.Euler.html
		Player.transform.localScale = new Vector3(1, 1, 1);
		Player.transform.localRotation = Quaternion.Euler(0, 0, 0);
		//enable the death animation
		Player.transform.GetComponent<Animator>().runtimeAnimatorController = Player.transform.GetComponent<PacMan>().PlayerDeathAnim;
		Player.transform.GetComponent<Animator>().enabled = true;
		//play pacman death sound
		transform.GetComponent<AudioSource>().clip = Grid.PacmanDeath;
		transform.GetComponent<AudioSource>().Play();

		yield return new WaitForSeconds(Time);

		Restart f = GetComponent<Restart>();//refer to pacman class
		//go to the restart function
		StartCoroutine(f.ThirdStageOfrestart(1));
	}




	// Update is called once per frame
	void Update()
    {
        
    }
}
