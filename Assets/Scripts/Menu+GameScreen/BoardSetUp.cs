using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class BoardSetUp : MonoBehaviour {

	public Text PlayerScore;
	public Image playerLives;
	public Image playerLives2;
	public Image playerLives3;
	private static int Width = 28;
	private static int Height = 36;
	public GameObject[,] Grid = new GameObject[Width, Height];
	public static int EnemyEatenConsecutiveScore;
	public Text EnemyEatenScoreText;
	public bool isObjectDead = false;
	public bool isobjecteaten = false;
	public static int playerOneLevel = 1;
	public int PelletsEaten = 0;
	public int NumberOfPelletsOnScreen = 0;
	public int score = 0;
	public Text readyText;

	public Text PlayerGame;
	public static int playerOneScore = 0;
	public int PlayerLives = 3;
	public bool increaselevel = false;
	public bool PlayerAlive = true;
	public bool ISAbleToflash = false;
	public float FlashTimer = 0.2f;
	private float FlashStart = 0;
	public AudioClip NormalAudio;	
	public AudioClip PacmanDeath;	
	public AudioClip GhostEaten;
	public Text BoardText;
	
	
	




	// Use this for initialization
	void Start()
	{
		{



		}

	}



	void Update() {

		LivesCheck();

		PelletCounter();

	}

	

	void PelletCounter() {

		if (PlayerAlive) {
			
				
				if (NumberOfPelletsOnScreen == PelletsEaten)
				{

					CompleteLevel(1);
				}
			}

		
	}

	void CompleteLevel(int Player) {

		if (Player == 1) {

			playerOneLevel++;
			//increment player one

		}

		StartCoroutine(ProcessWin(2));
	}




	void LivesCheck()
	{

		PlayerScore.text = playerOneScore.ToString();

		if (PlayerLives == 3)
		{
			playerLives.enabled = true;

			playerLives3.enabled = true;
			playerLives2.enabled = true;

		}
		else if (PlayerLives == 2)
		{
			playerLives3.enabled = true;
			playerLives3.enabled = false;
			playerLives2.enabled = true;

		}
		else if (PlayerLives == 1)
		{
			playerLives3.enabled = true;
			playerLives3.enabled = false;
			playerLives2.enabled = false;
		}
	}

	private void StartNextLevel() {

		SceneManager.LoadScene("MainGameVersion");
	}





	IEnumerator StartBlinking (Text blinkText) {

		yield return new WaitForSeconds (0.25f);

		blinkText.GetComponent<Text> ().enabled = !blinkText.GetComponent<Text> ().enabled;
		StartCoroutine (StartBlinking (blinkText));
	}




	IEnumerator ProcessWin(float delay)
	{

		GameObject pacMan = GameObject.Find("PacMan");
		pacMan.transform.GetComponent<PacMan>().PlayerIsAbleToMove = false;
		pacMan.transform.GetComponent<Animator>().enabled = false;

		transform.GetComponent<AudioSource>().Stop();

		GameObject[] i = GameObject.FindGameObjectsWithTag("Ghost");

		foreach (GameObject enemy in i)
		{

			enemy.transform.GetComponent<Ghost>().EnemyMovement = false;
			enemy.transform.GetComponent<Animator>().enabled = false;
		}

		yield return new WaitForSeconds(delay);
		StartNextLevel();

	}

	public IEnumerator ProcessGameOver (float delay) {

		yield return new WaitForSeconds (delay);

		SceneManager.LoadScene ("Menu");
	}

	



}

