using UnityEngine;
using System.Collections;

public class TutDialogue : MonoBehaviour {

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

	void OnTriggerEnter (Collider col)
	{
		if (!used && col.tag == "Player")
		{
			//player.speed = 0;
			player.BroadcastMessage ("StartDialogue", text);
			used = true;
		}
	}


}
