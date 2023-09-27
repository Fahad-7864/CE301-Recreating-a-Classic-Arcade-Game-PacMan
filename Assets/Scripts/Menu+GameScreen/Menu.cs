using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour {
	
	public static bool GameActive = true;

	public Text playerText1;
	public Text playerSelector;

	// Update is called once per frame
	void Update()
	{

		if (Input.GetKeyUp(KeyCode.Return))
		{

				SceneManager.LoadScene("MainGameVersion");
				GameActive = true;
				playerSelector.transform.localPosition = new Vector3(playerSelector.transform.localPosition.x, playerText1.transform.localPosition.y, playerSelector.transform.localPosition.z);
			}
		}

	}

