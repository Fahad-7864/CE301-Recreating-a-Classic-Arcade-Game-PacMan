using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitalStageOfGameScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
		Stage1OfBeginGameInstance();

	}


	public void Stage1OfBeginGameInstance()
	{
		//this is loaded first
		GameObject[] i = GameObject.FindGameObjectsWithTag("Ghost");
		BoardSetUp Grid = GetComponent<BoardSetUp>();//refer to pacman class

		foreach (GameObject enemy in i)
		{

			enemy.transform.GetComponent<SpriteRenderer>().enabled = false;
			enemy.transform.GetComponent<Ghost>().EnemyMovement = false;
		}

		GameObject pacMan = GameObject.Find("PacMan");
		pacMan.transform.GetComponent<SpriteRenderer>().enabled = false;
		pacMan.transform.GetComponent<PacMan>().PlayerIsAbleToMove = false;

		StartCoroutine(Stage2OfbeginGameInstance(1.0f));


	}


		IEnumerator Stage2OfbeginGameInstance(float time)
		{

			yield return new WaitForSeconds(time);

			GameObject[] i = GameObject.FindGameObjectsWithTag("Ghost");

			foreach (GameObject enemy in i)
			{

				enemy.transform.GetComponent<SpriteRenderer>().enabled = true;
			}

			GameObject pacMan = GameObject.Find("PacMan");
			pacMan.transform.GetComponent<SpriteRenderer>().enabled = true;

			//playerText.transform.GetComponent<Text> ().enabled = false;

			StartCoroutine(Stage3OfBeginGameInstance(2));
		}

		IEnumerator Stage3OfBeginGameInstance(float time)
		{

		
			yield return new WaitForSeconds(time);
		BoardSetUp Grid = GetComponent<BoardSetUp>();//refer to pacman class

		GameObject[] i = GameObject.FindGameObjectsWithTag("Ghost");

			foreach (GameObject enemy in i)
			{

				enemy.transform.GetComponent<Ghost>().EnemyMovement = true;
			}

			GameObject pacMan = GameObject.Find("PacMan");
			pacMan.transform.GetComponent<PacMan>().PlayerIsAbleToMove = true;
		Grid.BoardText.transform.GetComponent<Text>().enabled = false;

		Grid.readyText.transform.GetComponent<Text>().enabled = false;

			transform.GetComponent<AudioSource>().clip = Grid.NormalAudio;
			transform.GetComponent<AudioSource>().Play();
		}


	
	// Update is called once per frame
	void Update()
    {
        
    }
}
