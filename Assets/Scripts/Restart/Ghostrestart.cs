using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghostrestart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
	public void GHRestart()
	{
		Ghost GH = GetComponent<Ghost>();//refer to pacman class

		GH.EnemyMovement = true;
		GH.StateOfGame = Ghost.EnemyStates.Scatter;
		GH.SpeedOFEnemy = GH.RestartEnemySpeed;
		GH.StoreMoveSpeed = 0;
		GH.EnemyInHouseTimer = 0;
		GH.StateIncrementer = 1;
		GH.StateChangerTimer = 0;

		GH.TemporaryWaypoint = GH.OrignalWaypoint;

		if (GH.GhostHouseManipulator)
		{

			GH.Movement = Vector2.up;
			GH.GoalWaypoint = GH.TemporaryWaypoint.AdjacentWaypoints[0];

		}
		else
		{
			GhostDirectionDecision GDD = GetComponent<GhostDirectionDecision>();//refer to pacman class

			GH.Movement = Vector2.left;
			GH.GoalWaypoint = GDD.GhostDecisionMethod();
		}

		GH.LastWaypoint =GH. TemporaryWaypoint;
		Ghostanimation R = GetComponent<Ghostanimation>();//refer to pacman class

		R.AnimateinRealTime();

	}
	// Update is called once per frame
	void Update()
    {
        
    }
}
