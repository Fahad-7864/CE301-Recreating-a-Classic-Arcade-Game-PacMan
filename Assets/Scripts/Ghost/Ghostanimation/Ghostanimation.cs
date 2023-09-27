using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghostanimation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

	public RuntimeAnimatorController ghostUp;
	public RuntimeAnimatorController ghostDown;
	public RuntimeAnimatorController ghostLeft;
	public RuntimeAnimatorController ghostRight;
	public RuntimeAnimatorController ghostWhite;
	public RuntimeAnimatorController ghostBlue;
	public void AnimateinRealTime()
	{
		Ghost Gh = GetComponent<Ghost>();//Reference the Ghost class
		 if (Gh.StateOfGame == Ghost.EnemyStates.Eaten)
		{

			transform.GetComponent<Animator>().runtimeAnimatorController = null;

			if (Gh.Movement == Vector2.down) //if ghost is eaten and is travelling down change sprite to eyes travelling down
			{
				transform.GetComponent<SpriteRenderer>().sprite = Gh.ScaredStateSpriteDown;
			}
			else if(Gh.Movement == Vector2.up)//if ghost is eaten and is travelling uo change sprite to eyes travelling down
			{
				transform.GetComponent<SpriteRenderer>().sprite = Gh.ScaedStateEyesUp;
			}
			 
			else if (Gh.Movement == Vector2.left)//if ghost is eaten and is travelling left change sprite to eyes travelling down
			{
				transform.GetComponent<SpriteRenderer>().sprite = Gh.ScaredStateSpriteLeft;
			}
			else if (Gh.Movement == Vector2.right)//if ghost is eaten and is travelling right change sprite to eyes travelling down
			{
				transform.GetComponent<SpriteRenderer>().sprite = Gh.ScaredStateSpriteRight;
			}
		}


		if ( Gh.StateOfGame != Ghost.EnemyStates.Eaten && Gh.StateOfGame != Ghost.EnemyStates.Scared )//if the current mode isnt frighteneed 
		{

			if (Gh.Movement == Vector2.down)//if ghost is not eaten and isnt in scared and is travelling down animation sprite to  travelling down
			{

				transform.GetComponent<Animator>().runtimeAnimatorController = ghostDown;

			}
			else if (Gh.Movement == Vector2.up)///if ghost is not eaten and isnt in scared and is travelling up change animation to  travelling up
			{

				transform.GetComponent<Animator>().runtimeAnimatorController =ghostUp;

			}
			 
			else if (Gh.Movement == Vector2.left)///if ghost is not eaten and isnt in scared and is travelling left change animation to  travelling left
			{

				transform.GetComponent<Animator>().runtimeAnimatorController = ghostLeft;

			}
			else if (Gh.Movement == Vector2.right)///if ghost is not eaten and isnt in scared and is travelling right change animation to eyes travelling right
			{

				transform.GetComponent<Animator>().runtimeAnimatorController = ghostRight;

			}
			

		}

		//
		 if (Gh.StateOfGame == Ghost.EnemyStates.Scared)///if ghost is   in scared change aniamtor to blue sprite.
		{

			transform.GetComponent<Animator>().runtimeAnimatorController = ghostBlue;

		}
		
	}

	// Update is called once per frame
	void Update()
    {
        
    }
}
