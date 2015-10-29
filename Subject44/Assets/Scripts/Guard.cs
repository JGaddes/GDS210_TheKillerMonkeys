﻿using UnityEngine;
using System.Collections;

public class Guard : MonoBehaviour {

	public GameObject player;
	public PlayerController playerController;
	AudioSource deadguard; 

	// Use this for initialization
	void Start () 
	{

		playerController = player.GetComponent<PlayerController> ();
		deadguard = GetComponentInParent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Vector3.Distance (transform.position, player.transform.position) < 1.5f) {

			if(playerController.useBanana){
				if(Input.GetKeyDown(KeyCode.Space)) {
					Destroy (gameObject);
					deadguard.Play();
				}
			if(Input.GetKeyDown(KeyCode.Space)) {
				Destroy (gameObject);
				}
			}
		}
	}
}