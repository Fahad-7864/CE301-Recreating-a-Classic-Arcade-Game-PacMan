using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eat : MonoBehaviour
{

	private AudioSource audio;
	public AudioClip chomp1;
	public bool Audio = true;






	public void EatAudio()
	{
		//if audio is truel
		if (Audio)
		{
			audio.PlayOneShot(chomp1);
			Audio = true;

		}
	}
		void EatFunction()
	{
		LocationOfBlock BlockPos = GetComponent<LocationOfBlock>();//reference to Location of block class

		GameObject j = BlockPos.BlockLocation(transform.position);

		if (j != null)//if object is not null at the position
		{
			Frame Block = j.GetComponent<Frame>(); //get the assigned value of that square e.g pellet,portal
			if (Block != null)//if the 
			{

				if (Block.Eaten==false)
					//if the block/frame has not been eaten
					if (Block.Pelletobject || Block.Powerpellet)
					//if the block is a pellet or a power pellet
				{
	
							//disable the sprite that is in that frame pellet.
							j.GetComponent<SpriteRenderer>().enabled = false;

							Block.Eaten = true;
							//set that block to eaten to represent the frame can no longer be incremented.
							if (Menu.GameActive)
							//if the game instnace is acitve
							{

								BoardSetUp.playerOneScore += 10;
								GameObject.Find("Manager").transform.GetComponent<BoardSetUp>().PelletsEaten++;

							}
						
								
						//playaudio	
						EatAudio();

							if (Block.Powerpellet)
							{
							//start frightened mode if user eats pellet
								GameObject[] enemy = GameObject.FindGameObjectsWithTag("Ghost");

								foreach (GameObject i in enemy)
								{

									i.GetComponent<Eat>().StartFrightenedMode();
								}
							}
						}

					}
			

		}
	}



	public void StartFrightenedMode()
	{
		GhostStates GHState = GetComponent<GhostStates>();//refer to ghosstates class
		Ghost GH = GetComponent<Ghost>();//refer to ghost class

		if (GH.StateOfGame != Ghost.EnemyStates.Eaten)
		{

			GH.ScaredTimer = 0;
		
			BoardSetUp.EnemyEatenConsecutiveScore = 200;
			GHState.ImplementChangeOFState(Ghost.EnemyStates.Scared);
		}
	}


	// Start is called before the first frame update
	void Start()
    {
		audio = transform.GetComponent<AudioSource>();

	}

	// Update is called once per frame
	void Update()
    {
			EatFunction();

		}
	}
