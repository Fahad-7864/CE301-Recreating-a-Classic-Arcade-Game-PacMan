using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pacmanrestart : MonoBehaviour
{
    GameObject Player;
    public void PacmanRestart()
    {
        PacMan R = GetComponent<PacMan>();//refer to pacman class
        PacMan reloc = GetComponent<PacMan>();//refer to pacman class

        R.PlayerIsAbleToMove = true;

        R.Waypoint = R.InitialPositionOfUser;

        R.choosemovementposition = Vector2.left;

        transform.GetComponent<Animator>().runtimeAnimatorController = R.Eatanim;
        transform.GetComponent<Animator>().enabled = true;

       R.MoveLocationOfpac(R.movementposition);
    }
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("PacMan");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
