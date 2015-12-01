using UnityEngine;
using System.Collections;

public class TutDialogue02 : MonoBehaviour {
	
	public PlayerController player;
	public int text;
	private bool used = false;
	
	// Use this for initialization
	void Start () {
		
		player = GameObject.Find("Player").GetComponent<PlayerController>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerStay (Collider col)
	{
		if (!used && col.tag == "Player")
		{
			if(Input.GetKeyDown(KeyCode.E))
			{
				player.canMove = false;
				player.BroadcastMessage ("StartDialogue", text);
				used = true;
			}

		}
	}
	
	
}
