using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Physicschecker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public bool GhostContrictedWAypoint()
    {//this is called by the another function in helping keep objects within the game
        Ghost G = GetComponent<Ghost>();//refer to Ghost class

        float WaypointGoal = GhostGetDistanceFromWaypoint(G.GoalWaypoint.transform.position);
        float WaypointPosition = GhostGetDistanceFromWaypoint(transform.localPosition);
        //if the waypoint position is greater than the wayypoint goal
        return WaypointPosition > WaypointGoal;
    }

    float GhostGetDistanceFromWaypoint(Vector2 GoalLocation)
    {
        Ghost G = GetComponent<Ghost>();//refer to Ghost class

        Vector2 VectorMag = GoalLocation - (Vector2)G.LastWaypoint.transform.position;
        //return the length of the vector
        //which is the square rooot of (x*x+y*y).
        return VectorMag.sqrMagnitude;
        //https://docs.unity3d.com/ScriptReference/Vector2-magnitude.html
    }

    public float PlayerDistanceFromWaypoint(Vector2 GoalLocation)
    {
        PacMan Pac = GetComponent<PacMan>();//refer to pacman class

        Vector2 VectorMag = GoalLocation - (Vector2)Pac.LastWaypoint.transform.position;
        //return the length of the vector
        //which is the square rooot of (x*x+y*y).

        return VectorMag.sqrMagnitude;
        //https://docs.unity3d.com/ScriptReference/Vector2-magnitude.html
    }

    public bool PlayerConstrictedWaypoint()
    {
        PacMan Pac = GetComponent<PacMan>();//refer to pacman class

        float WaypointGoal = PlayerDistanceFromWaypoint(Pac.Waypointobjective.transform.position);
        float WaypointPosition = PlayerDistanceFromWaypoint(Pac.transform.localPosition);

        return WaypointPosition > WaypointGoal;
    }

    
    // Update is called once per frame
    void Update()
    {
        
    }
}
