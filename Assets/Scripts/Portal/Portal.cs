using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public GameObject PortalComponent(Vector2 Coord)
    {
        //find the portal component in the grid
       GameObject Block = GameObject.Find
            ("Manager").GetComponent<BoardSetUp>().Grid[(int)Coord.x, (int)Coord.y];
        if (Block != null)//if block isnt null
        {
            if (Block.GetComponent<Frame>().Portalwaypoint)
            {//get the value that is in frame
                GameObject Portal2 = Block.GetComponent<Frame>().Portalwaypointobject;//initialise variable to game object other portal
                return Portal2;
            }
        }
        return null;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
