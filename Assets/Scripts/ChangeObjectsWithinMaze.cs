using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeObjectsWithinMaze : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
		ChangeObject();

	}

	void ChangeObject()
	{

		BoardSetUp GR = GetComponent<BoardSetUp>();//refer to pacman class
		//loop through array and get coordinates of position of game objects
		Object[] items = FindObjectsOfType(typeof(GameObject));

		foreach (GameObject item in items)
		{

			Vector2 COORD = item.transform.position;

			if (item.name != "PacMan")
				if (item.name != "NormalPellets")
					if (item.name != "Waypoint")
						if (item.name != "Maze")
							if (item.name != "Waypoints")
								if (item.tag != "Ghost")
									if (item.tag != "ScatterNodes")
										if (item.name != "Canvas")
											if (item.tag != "UI")
											{

												if (item.GetComponent<Frame>() != null)
												{

													if (item.GetComponent<Frame>().Pelletobject || item.GetComponent<Frame>().Powerpellet)
													{

														GR.NumberOfPelletsOnScreen++;
													}
												}

												GR.Grid[(int)COORD.x, (int)COORD.y] = item;

											}

		}
	}
	// Update is called once per frame
	void Update()
    {
        
    }
}
