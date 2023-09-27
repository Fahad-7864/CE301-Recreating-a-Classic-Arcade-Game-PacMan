using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Restart : MonoBehaviour
{
	// Start is called before the first frame update
	GameObject pacMan;

	public void FirstStageOfRestart()//this class finds both Pacman and ghosts and 
					//this class is restrt and also a public void where as process restart

		//stage 1 of resstart
	{
		BoardSetUp R = GetComponent<BoardSetUp>();//refer to pacman class

		R.readyText.transform.GetComponent<Text>().enabled = false;

		GameObject pacMan = GameObject.Find("PacMan");
		//PacmanRestart();//this uses pacmans restart

		pacMan.transform.GetComponent<Pacmanrestart>().PacmanRestart();//this uses pacmans restart
																	   //PacmanRestart(pacMan);

		GameObject[] o = GameObject.FindGameObjectsWithTag("Ghost");

		foreach (GameObject ghost in o)
		{

			ghost.transform.GetComponent<Ghostrestart>().GHRestart();
		}

		transform.GetComponent<AudioSource>().clip = R.NormalAudio;
		transform.GetComponent<AudioSource>().Play();

		R.isObjectDead = false;
	}

	public IEnumerator SecondStageOfrestart(float Time)
		//stage 2 of restart
	{
		BoardSetUp R = GetComponent<BoardSetUp>();//refer to pacman class

		R.BoardText.transform.GetComponent<Text>().enabled = false;

		GameObject[] o = GameObject.FindGameObjectsWithTag("Ghost");

		foreach (GameObject ghost in o)
		{

			ghost.transform.GetComponent<SpriteRenderer>().enabled = true;
			ghost.transform.GetComponent<Ghost>().MoveToStartingPosition();
		}

		GameObject pacMan = GameObject.Find("PacMan");

		pacMan.transform.GetComponent<Animator>().enabled = false;
		pacMan.transform.GetComponent<SpriteRenderer>().enabled = true;
		pacMan.transform.GetComponent<PacMan>().MoveToStartingPosition();

		yield return new WaitForSeconds(Time);

		FirstStageOfRestart();
	}



	public IEnumerator ThirdStageOfrestart(float Time)
		//stage 3 of restart
	{
		BoardSetUp R = GetComponent<BoardSetUp>();//refer to pacman class

		R.PlayerLives -= 1;

		if (R.PlayerLives == 0) 
		{

			R.BoardText.transform.GetComponent<Text>().enabled = true;
			R.readyText.transform.GetComponent<Text>().text = "GAME OVER";
			R.readyText.transform.GetComponent<Text>().color = Color.red;
			R.readyText.transform.GetComponent<Text>().enabled = true;

			GameObject Player = GameObject.Find("PacMan");
			Player.transform.GetComponent<SpriteRenderer>().enabled = false;
			transform.GetComponent<AudioSource>().Stop();

			StartCoroutine(R.ProcessGameOver(2));//this is for how long to display the game over screen

		}
		else
		{
			R.BoardText.transform.GetComponent<Text>().enabled = true;
			R.readyText.transform.GetComponent<Text>().enabled = true;

			GameObject pacMan = GameObject.Find("PacMan");
			pacMan.transform.GetComponent<SpriteRenderer>().enabled = false;

			transform.GetComponent<AudioSource>().Stop();

			yield return new WaitForSeconds(Time);

			StartCoroutine(SecondStageOfrestart(1));
		}
	}






	void Start()
    {
		pacMan = GameObject.FindGameObjectWithTag("PacMan");

	}

	// Update is called once per frame
	void Update()
    {
        
    }
}
