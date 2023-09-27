using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetWaypointLocation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
   public Waypoints WaypointLocation(Vector2 coordinates)
    {
        //this scripts purpose is to detect coordinates of a specific block
        GameObject Block = GameObject.Find("Manager").GetComponent<BoardSetUp>
            
            ().Grid[(int)coordinates.x, (int)coordinates.y];

        if (Block != null)
        {
            //Return coordinates of the block found
            return Block.GetComponent<Waypoints>();
        }

        return null;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
