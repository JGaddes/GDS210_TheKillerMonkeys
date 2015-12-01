using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NoKey : MonoBehaviour {
	
	public PlayerController player;
	public int noKey;
	
	public bool key;
	private bool used = false;

	
	// Use this for initialization
	void Start () {
		
		key = false;

		player = GameObject.Find("Player").GetComponent<PlayerController>();
		
		//source = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerStay (Collider col)
	{
		if (!used && col.tag == "Player")
		{	
			if(!key)
			{
				if(Input.GetKeyDown(KeyCode.E))
				{
					//you need a key dialogue
					player.BroadcastMessage ("StartDialogue", noKey);
					
					used = true;
				}
			}
		}
	}	

}

