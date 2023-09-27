using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacmanUserController : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject Player;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("PacMan");

      
    }


    void CheckInputFromPlayer()
    {//remove check input from class
        PacMan refscript = GetComponent<PacMan>();//refer to pacman class
        PacMan f = GetComponent<PacMan>();//refer to pacman class



        if (Input.GetKeyDown(KeyCode.UpArrow))
        {

            f.MoveLocationOfpac(Vector2.up);

        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {

            f.MoveLocationOfpac(Vector2.right);

        }
     
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {

            f.MoveLocationOfpac(Vector2.down);
        }

       else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {

            f.MoveLocationOfpac(Vector2.left);

        }
    }

    // Update is called once per frame
    void Update()
    {

        PacMan refscript = GetComponent<PacMan>();//refer to pacman class

        if (refscript.PlayerIsAbleToMove)
        {
            CheckInputFromPlayer();



        }
    }
}
