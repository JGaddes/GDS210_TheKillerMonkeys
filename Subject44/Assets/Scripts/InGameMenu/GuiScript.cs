﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class GuiScript : MonoBehaviour {
	
	public PlayerController playerController;
	public int count;
	public float cooldown = 2;

    //KepPad Variables
    public Text keyPadText;
    public Canvas keyPad;
    public string password = "";

    //Computer Variables
    public InputField compInput;
    public Canvas Computer;
    public string loginPass = "";

    private Animator anim;
    private Animator anim2;

	AudioSource KeyPressed; 
	AudioSource PasswordSuccess; 
	AudioSource PasswordFail;



    // Use this for initialization
    void Start () {
	
		playerController.GetComponent <PlayerController>();
		//bananaSlider.value = 0;

        
        anim = keyPadText.GetComponent<Animator>();
        keyPad.enabled = false;
        anim.enabled = false;

        anim2 = Computer.gameObject.GetComponent<Animator>();
        Computer.enabled = false;
        anim2.enabled = false;

		AudioSource[] allMyAudioSources = GetComponents<AudioSource>();
		KeyPressed = allMyAudioSources[0];
		PasswordSuccess = allMyAudioSources[1];
		PasswordFail = allMyAudioSources [2];
		      
    }
	
	// Update is called once per frame
	void Update () {

		//bananaSlider.value -=  Time.deltaTime * cooldown; 

		//if (Input.GetKeyDown (KeyCode.B) && bananaSlider.value == 0) {
			
		//	if (count < 3)
		//	{
		//		bananaList[count].gameObject.GetComponent<Image> ().enabled = false;
		//		count++;
		//		playerController.BananaMode();
		//		bananaSlider.value = 100;
		//	}
	 //   }
    }

    public void CodeCheck(string other) {

        switch (other.ToLower()){

            case "password":
                Debug.Log("Correct Password");
                anim2.enabled = true;
                break;
            default:
                Debug.Log("Wrong Code Nerd!");
                break;
        }
    }

    public void ClickLetter(string letterClicked)
    {
        if (keyPadText.text.Length < 4) {

            string tempCurString = keyPadText.text;
            string tempNewString = tempCurString + letterClicked;
            keyPadText.text = tempNewString;
			KeyPressed.Play ();
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
            Debug.Log("Unlocking something!");
			PasswordSuccess.Play();
            //THIS IS WHERE YOU CAN MAKE IT OPEN A DOOR ETC!
            
        }
        else {

            Debug.Log("Wrong code, try again");
            string tempString = tempPass.Substring(0, tempPass.Length - tempPass.Length);
            keyPadText.text = tempString;
			PasswordFail.Play();
        }
    }

    //KEYPAD FUNCTIONS!!

    public void KeyPadActive() {

        keyPad.enabled = true;
    }

    public void KeyPadUnActive()
    {

        keyPad.enabled = false;
    }

    IEnumerator MyCoroutine()
    {

        //Disable Raycast so the Keypad becomes unusable
        keyPad.GetComponent<GraphicRaycaster>().enabled = false;
        anim.enabled = true;
        yield return new WaitForSeconds(2);
        keyPad.enabled = false;
    }

    //END OF KEYPAD FUNCTIONS

    //COMPUTER FUNCTIONS!!

    public void ComputerActive() {

        Computer.enabled = true;
    }

    public void ComputerUnActive()
    {

        Computer.enabled = false;
        playerController.speed = 5;
    }

    public void UnlockDoors() {

        Debug.Log("Doors Unlocking!");
    }

    public void DisableCameras() {

        Debug.Log("Cameras Disabled!");
    }

    //END OF COMPUTER FUNCTIONS

    
}