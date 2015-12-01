using UnityEngine;
using System.Collections;

public class EndTutorial : MonoBehaviour {
	
	public PlayerController player;
	public GameObject guard1;
	public GameObject guard2;
	public GameObject guard3;
	public int text;
	private bool used = false;
	public bool endTute = true;
	
	// Use this for initialization
	void Start () {
		
		player = GameObject.Find("Player").GetComponent<PlayerController>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if(endTute == true)
		{
			if(guard1 == null && guard2 == null && guard3 == null)
			{
				player.BroadcastMessage ("StartDialogue", text);
				endTute = false;

				used = true;
			}
		}
		
	}
	
	
	
}
