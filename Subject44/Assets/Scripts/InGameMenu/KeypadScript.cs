﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class KeypadScript : MonoBehaviour {
	
	//KepPad Variables
	public Canvas keyPad;
	public Text keyPadText;
	public string password = "";
	public GameObject exitDoor;
	public PlayerController playerController;
    public ChildCollider _childCollider;
	public bool _openAccess;
	public Text popUpText;
    public Image idCard;
	public AudioClip buttonPressed, keypadSuccess, keypadFailure; 
	AudioSource source;
	
	private Animator anim;

	
	// Use this for initialization
	void Start () {
		popUpText = playerController.gameObject.GetComponent<PlayerController> ().interactText;
		playerController.GetComponent<PlayerController>();
		anim = keyPadText.GetComponent<Animator>();

		keyPad.enabled = false;
		anim.enabled = false;
		_openAccess = false;
        idCard.enabled = false;
        KeyPadUnActive();

		source = GetComponent<AudioSource> ();
	}

    void Update() {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            KeyPadUnActive();
        }


		if ((Input.GetKeyDown(KeyCode.Keypad1) && keyPadText.text.Length < 4) || (Input.GetKeyDown(KeyCode.Alpha1) && keyPadText.text.Length < 4)) {
			
			string tempCurString = keyPadText.text;
			string tempNewString = tempCurString + "1";
			keyPadText.text = tempNewString;
		}
    }
	

	void OnTriggerStay(Collider other)
	{	
		if (other.CompareTag ("Player") && playerController.havePill || _openAccess == true )
		{
			if(playerController.havePill)
			{				
				popUpText.enabled = true;
				if(Input.GetKeyDown(KeyCode.E))
				{
					popUpText.enabled = false;
					KeyPadActive();
					if(_openAccess == false)
					{
						_openAccess = true;
						playerController.pillCount -= 1;
					}
				}
			}
		}
	}

	void OnTriggerExit(){
	
		popUpText.enabled = false;
        KeyPadUnActive();
	}
	
	public void ClickLetter(string letterClicked)
	{
		if (keyPadText.text.Length < 4) {
			string tempCurString = keyPadText.text;
			string tempNewString = tempCurString + letterClicked;
			keyPadText.text = tempNewString;
			source.PlayOneShot(buttonPressed);
		}
	}
	

	public void ClickBackspace()
	{
		string tempGetString = keyPadText.text;
		if (tempGetString.Length > 0)
		{
			string tempString = tempGetString.Substring(0, tempGetString.Length - 1);
			keyPadText.text = tempString;
		}
	}
	
	public void ClickEnter() {
		
		string tempPass = keyPadText.text;
		
		if (password == tempPass){
			StartCoroutine(MyCoroutine());
			exitDoor.SetActive(false);		
			source.PlayOneShot(keypadSuccess);
		}
		else {
			Debug.Log(password);
			Debug.Log (tempPass);
			string tempString = tempPass.Substring(0, tempPass.Length - tempPass.Length);
			keyPadText.text = tempString;;
		}
	}
	
	//KEYPAD FUNCTIONS!!
	
	public void KeyPadActive() {
		if(anim.enabled == false){
			keyPad.enabled = true;
			playerController.canMove = false;
		}

        if (_childCollider.haveIdCard == true)
        {
            _childCollider.idCard.SetActive(false);
            idCard.enabled = true;
        }

        playerController.enabled = false;
    }
	
	public void KeyPadUnActive()
	{
		
		keyPad.enabled = false;
        idCard.enabled = false;
		playerController.canMove = true;
        playerController.enabled = true;
    }
	
	IEnumerator MyCoroutine()
	{
		//Disable Raycast so the Keypad becomes unusable
		keyPad.GetComponent<GraphicRaycaster>().enabled = false;
		anim.enabled = true;
		yield return new WaitForSeconds(2);
		keyPad.enabled = false;
		playerController.canMove = true;
		playerController.enabled = true;
	}
}
