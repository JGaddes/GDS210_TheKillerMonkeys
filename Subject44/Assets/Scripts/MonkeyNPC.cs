using UnityEngine;
using System.Collections;

public class MonkeyNPC : MonoBehaviour {

	public PlayerController player;
	public int text;
	private bool used = false;
	public GameObject cage01, cage02;
	
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
				//player.speed = 0;
				player.BroadcastMessage ("StartDialogue", text);
				used = true;

				cage01.GetComponent<MonkeyKin>().key = true;
				cage02.GetComponent<MonkeyKin>().key = true;

			}

		}
	}
}

