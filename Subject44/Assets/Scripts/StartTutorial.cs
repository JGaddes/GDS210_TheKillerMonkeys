using UnityEngine;
using System.Collections;

public class StartTutorial : MonoBehaviour {
	
	public PlayerController player;
	public int text;
	private bool used = false;
	public GameObject splash;
	public bool done = false;
	
	// Use this for initialization
	void Start () {
		
		player = GameObject.Find("Player").GetComponent<PlayerController>();
		
	}
	
	// Update is called once per frame
	void Update () {

		if(!used && done == true)
		{
			player.canMove = false;
			player.BroadcastMessage ("StartDialogue", text);
			used = true;
	
		}
	}

	
	
}
