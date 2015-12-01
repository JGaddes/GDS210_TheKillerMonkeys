using UnityEngine;
using System.Collections;

public class TutBanana : MonoBehaviour {
	
	public PlayerController player;
	public int text;
	private bool used = false;
	public bool bananaTutorial = true;
	
	// Use this for initialization
	void Start () {
		
		player = GameObject.Find("Player").GetComponent<PlayerController>();
		
	}
	
	// Update is called once per frame
	void Update () {

		if(bananaTutorial == true)
		{
			if(player.bananaCount == 1)
			{
				bananaTutorial = false;
				player.canMove = false;
				player.BroadcastMessage ("StartDialogue", text);
				used = true;
			}
		}

	}

	
	
}
