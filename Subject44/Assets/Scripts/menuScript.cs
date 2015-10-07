using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class menuScript : MonoBehaviour {

	public Canvas exitMenu;
	public Canvas levelMenu;
	public Button startText;
	public Button exitText;
	public Button levelText;

	public string levelName;

	// Use this for initialization
	void Start () {
	
		exitMenu = exitMenu.GetComponent <Canvas> ();
		startText = startText.GetComponent <Button> ();
		exitText = exitText.GetComponent <Button> ();

		exitMenu.enabled = false;
		levelMenu.enabled = false;
	}
	
	public void ExitPress(){

		exitMenu.enabled = true;
		startText.enabled = false;
		exitText.enabled = false;
		levelText.enabled = false;
	}

	public void LevelPress(){
	
		exitMenu.enabled = false;
		levelMenu.enabled = true;
		startText.enabled = false;
		exitText.enabled = false;
		levelText.enabled = false;
	}

	public void NoPress(){

		exitMenu.enabled = false;
		levelMenu.enabled = false;
		startText.enabled = true;
		exitText.enabled = true;
		levelText.enabled = true;
	}

	public void StartLevel(){

		Application.LoadLevel (levelName);
	}

	public void ExitGame(){

		Application.Quit ();
		Debug.Log ("You have quit the game");
	}
}
