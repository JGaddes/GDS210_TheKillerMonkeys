﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MonkeyKin : MonoBehaviour {

	public PlayerController player;
	public int textHelp, textYes, textNo;

	public bool key;
	private bool used = false;
	public AudioClip badMonkey, goodMonkey;
	public AudioSource source;
	public AudioSource cameraSource;
	public GameObject yesButt, noButt;
	public Text yesTxt, noTxt;
	public GameObject cageDoor, monkeyKin;


	// Use this for initialization
	void Start () {
	
		key = false;

		yesButt.SetActive (false);
		noButt.SetActive (false);

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
			if(key)
			{
				if(Input.GetKeyDown(KeyCode.E))
				{
					//Will you help me? dialogue
					player.BroadcastMessage ("StartDialogue", textHelp);

					used = true;

					yesButt.SetActive (true);
					noButt.SetActive (true);
					yesTxt.enabled = true;
					noTxt.enabled = true;
				}
			}
		}
	}

	public void saveMonkey()
	{
		//thank you dialogue
		player.BroadcastMessage ("StartDialogue", textYes);
		source.PlayOneShot(goodMonkey, 1f);
		cameraSource.volume = 0.1f; 
		Invoke("VolumeBackUp", 4.5f);

		cageDoor.transform.Rotate(0, 110f, 0);

		monkeyKin.SetActive (false);

		yesButt.SetActive (false);
		noButt.SetActive (false);
		yesTxt.enabled = false;
		noTxt.enabled = false;

	}

	public void leaveMonkey()
	{
		//sad dialogue
		player.BroadcastMessage ("StartDialogue", textNo);
		source.PlayOneShot(badMonkey, 1f);
		cameraSource.volume = 0.1f; 
		Invoke("VolumeBackUp", 4.5f);

		yesButt.SetActive (false);
		noButt.SetActive (false);
		yesTxt.enabled = false;
		noTxt.enabled = false;
	}

	public void VolumeBackUp()
	{
		cameraSource.volume = 0.4f;
		
	}
}
