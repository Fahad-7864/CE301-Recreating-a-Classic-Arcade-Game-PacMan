using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedAI : MonoBehaviour
{
    private GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("PacMan");


}
public Vector2 RedTarget()
    {
        //find the position of the player
        Vector2 PositionOfPlayer = Player.transform.localPosition;
        //Round the x and y coordinatees of the player and set that to the goal position
        //red ghosts a.i is simple as it will just continiously chase pacman around
        Vector2 GoalPosition = new Vector2(Mathf.RoundToInt(PositionOfPlayer.x), Mathf.RoundToInt(PositionOfPlayer.y));

        return GoalPosition;
        Debug.Log("x" + GoalPosition);

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
