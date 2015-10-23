﻿using UnityEngine;
using System.Collections;

public class Guard : MonoBehaviour {

	public GameObject player;

	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Vector3.Distance (transform.position, player.transform.position) < 1.5f) {
			if(Input.GetKeyDown(KeyCode.LeftShift)) {
				Destroy (gameObject);
			}
		}
	}
}
