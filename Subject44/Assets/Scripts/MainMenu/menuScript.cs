using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class menuScript : MonoBehaviour {

	public Canvas exitMenu;
	public Canvas levelMenu;
	public Canvas creditMenu;
	public Button startText;
	public Button exitText;
	public Button levelText;
	public Button creditText;

	public string levelName;

	// Use this for initialization
	void Start () {
	
		exitMenu = exitMenu.GetComponent <Canvas> ();
		creditMenu = creditMenu.GetComponent <Canvas> ();
		startText = startText.GetComponent <Button> ();
		exitText = exitText.GetComponent <Button> ();

		exitMenu.enabled = false;
		levelMenu.enabled = false;
		creditMenu.enabled = false;
	}
	
	public void ExitPress(){

		exitMenu.enabled = true;
		startText.enabled = false;
		exitText.enabled = false;
		levelText.enabled = false;
		creditText.enabled = false;
	}

	public void LevelPress(){
	
		exitMenu.enabled = false;
		levelMenu.enabled = true;
		creditMenu.enabled = false;
		startText.enabled = false;
		exitText.enabled = false;
		levelText.enabled = false;
		creditText.enabled = false;
	}

	public void CreditPress(){
	
		exitMenu.enabled = false;
		levelMenu.enabled = false;
		creditMenu.enabled = true;
		startText.enabled = false;
		exitText.enabled = false;
		levelText.enabled = false;
		creditText.enabled = false;
	}

	public void NoPress(){

		exitMenu.enabled = false;
		levelMenu.enabled = false;
		creditMenu.enabled = false;
		startText.enabled = true;
		exitText.enabled = true;
		levelText.enabled = true;
		creditText.enabled = true;
	}

	public void StartLevel(){

		Application.LoadLevel (levelName);
	}

	public void ExitGame(){

		Application.Quit ();
		Debug.Log ("You have quit the game");
	}
}
