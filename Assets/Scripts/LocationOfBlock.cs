using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationOfBlock : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public GameObject BlockLocation(Vector2 Coord)
    {
        //find the coordinates of block x and y 
        int BlockX = Mathf.RoundToInt(Coord.x);
        int BlockY = Mathf.RoundToInt(Coord.y);

        GameObject Block = GameObject.Find("Manager").GetComponent<BoardSetUp>().Grid[BlockX, BlockY];

        if (Block != null)
            return Block;

        return null;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
