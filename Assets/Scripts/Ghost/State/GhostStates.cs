using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostStates : MonoBehaviour
{



	public void ChangeStateOfGhosts()
	{
		Ghost GH = GetComponent<Ghost>();//refer to Ghost class
		Ghostanimation GHanim = GetComponent<Ghostanimation>();//refer to Ghostanimation class

		if (GH.StateOfGame != Ghost.EnemyStates.Scared)//if the current state of the enemy is not in scared
		{//incrmeent the timer in delta time
			GH.StateChangerTimer += Time.deltaTime;
		}
		switch (GH.StateOfGame)
		{
			//if the ghost is in the scared statte
			case Ghost.EnemyStates.Scared:
				GH.ScaredTimer += Time.deltaTime;
				//increment time in delta time to allow ghosts to stay in scared state for specified duation
				if (GH.ScaredTimer >= GH.DurationOfScaredState)
				{//if the scared timer reaches how long the duration of the timer is
					GH.GhostAudio.clip = GameObject.Find("Manager").transform.GetComponent<BoardSetUp>().NormalAudio;
					GH.GhostAudio.Play();
					//play soundtrack
					GH.ScaredTimer = 0;
					//then change the mode the last state the game was in
					//whichh would either be chase or scatter.
					ImplementChangeOFState(GH.LastStateOfGame);
				}
				if (GH.ScaredTimer >= GH.startBlinkingAt)
				{//if the duration reaches 7 second, make the ghost flash in order to display that the timer is going off.
					GH.blinkTimer += Time.deltaTime;
					if (GH.blinkTimer >= 0.1f)
					{
						GH.blinkTimer = 0f;
						if (GH.BLinkInScaredState)
						{

							transform.GetComponent<Animator>().runtimeAnimatorController = GHanim.ghostBlue;
							GH.BLinkInScaredState = false;
						}
						else
						{

							transform.GetComponent<Animator>().runtimeAnimatorController = GHanim.ghostWhite;
							GH.BLinkInScaredState = true;
						}
					}

				}
				break;

			case Ghost.EnemyStates.Scatter:
				//if the game is a Scatter State
				//then change the current state to chase
				if (GH.StateChangerTimer > GH.ScatterTimer[GH.StateIncrementer])
				{
					//if the Normal timer is ahead  of the scatter timer
					//change the stateincrementer
					ImplementChangeOFState(Ghost.EnemyStates.Chase);//change mode to Chase
					GH.StateChangerTimer = 0;
				}
				break;
				//if the game is in chase
				//change the 
			case Ghost.EnemyStates.Chase:
				if (GH.StateChangerTimer > GH.ChaseTimer[GH.StateIncrementer])
				{
					//if the 
					GH.StateIncrementer = (GH.StateIncrementer + 1) % 4;
					ImplementChangeOFState(Ghost.EnemyStates.Scatter);//Change mode fro 
					GH.StateChangerTimer = 0;
				}
				break;
		}
	}

	public void ImplementChangeOFState(Ghost.EnemyStates State)
	{//this method gets called by changeghost state to allow transition of all states in the game accoring to timers.
		Ghost GH = GetComponent<Ghost>();//refer to ghsot class
		//if the state of the game is in scarerd, Set the Speed 
		if (GH.StateOfGame == Ghost.EnemyStates.Scared)
		{//if the state of the game is in scared

			GH.SpeedOFEnemy = GH.StoreMoveSpeed;
			//set the speed of ghosts back to their norml speed
		}
		if (State == Ghost.EnemyStates.Scared)
		{
			//if the paremeter is in scared mode
			//change the speed of the stored move speed of the enemy
			//change the speedof enemyinto the scared state
			//this is to change the speed of ghosts in scared state.
			GH.StoreMoveSpeed = GH.SpeedOFEnemy;
			GH.SpeedOFEnemy = GH.ScaredStateSpeed;
		}

		if (GH.StateOfGame != State)
		{//if the state of ghost is not the parameter defined in the function
			//so if the 
			GH.LastStateOfGame = GH.StateOfGame;
			//change the state of the game to the paremeter used.
			GH.StateOfGame = State;
		}
		Ghostanimation R = GetComponent<Ghostanimation>();//refer to animation class class

		R.AnimateinRealTime();
	}
	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
