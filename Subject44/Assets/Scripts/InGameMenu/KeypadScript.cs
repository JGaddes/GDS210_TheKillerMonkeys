using UnityEngine;
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
	public bool _openAccess;
	public Text interactPrompt;
	
	private Animator anim;
	
	//AudioSource KeyPressed; 
	//AudioSource PasswordSuccess; 
	//AudioSource PasswordFail;
	
	// Use this for initialization
	void Start () {
		
		playerController.GetComponent<PlayerController>();
		anim = keyPadText.GetComponent<Animator>();

		keyPad.enabled = false;
		anim.enabled = false;
		_openAccess = false;
		interactPrompt.enabled = false;
		
		playerController.pillCount += 2;
		
		KeyPadUnActive();
		//AudioSource[] allMyAudioSources = GetComponents<AudioSource>();
		//KeyPressed = allMyAudioSources[0];
		//PasswordSuccess = allMyAudioSources[1];
		//PasswordFail = allMyAudioSources [2];
	}

	void OnTriggerEnter(){
	
		if(anim.enabled == false){
			interactPrompt.enabled = true;
		}
	}

	void OnTriggerStay(Collider other){

		if(Input.GetKeyDown(KeyCode.E)){

			interactPrompt.enabled = false;

			if (other.CompareTag ("Player") && playerController.havePill || _openAccess == true ){
			
				KeyPadActive();

				if(_openAccess == false){
				
					_openAccess = true;
					playerController.pillCount -= 1;
				}
			}
		}
	}

	void OnTriggerExit(){
	
		interactPrompt.enabled = false;
	}
	
	public void ClickLetter(string letterClicked)
	{
		if (keyPadText.text.Length < 4) {
			
			string tempCurString = keyPadText.text;
			string tempNewString = tempCurString + letterClicked;
			keyPadText.text = tempNewString;
			//KeyPressed.Play ();
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
			//PasswordSuccess.Play();

			//exitDoor.SetActive(false);
			exitDoor.GetComponent<Collider> ().enabled = true;

			
		}
		else {
			
			Debug.Log("Wrong code, try again");
			Debug.Log(password);
			Debug.Log (tempPass);
			string tempString = tempPass.Substring(0, tempPass.Length - tempPass.Length);
			keyPadText.text = tempString;
			//PasswordFail.Play();
		}
	}
	
	//KEYPAD FUNCTIONS!!
	
	public void KeyPadActive() {
		if(anim.enabled == false){
			
			keyPad.enabled = true;
			playerController.canMove = false;
		}
	}
	
	public void KeyPadUnActive()
	{
		
		keyPad.enabled = false;
		playerController.canMove = true;
	}
	
	IEnumerator MyCoroutine()
	{
		
		//Disable Raycast so the Keypad becomes unusable
		keyPad.GetComponent<GraphicRaycaster>().enabled = false;
		anim.enabled = true;
		yield return new WaitForSeconds(2);
		keyPad.enabled = false;
		playerController.canMove = true;
	}
}
