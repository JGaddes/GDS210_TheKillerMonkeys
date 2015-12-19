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
    public ChildCollider _childCollider;
	public bool _openAccess;
	public Text popUpText;
    public Image idCard;
	public Text loginInfo;
	public AudioClip buttonPressed, keypadSuccess, keypadFailure; 
	public AudioSource source;
	
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
		loginInfo.enabled = false;
        KeyPadUnActive();
	}

    void Update() {
		if (keyPad.enabled) {
			popUpText.enabled = false;
		}

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            KeyPadUnActive();
        }

        //KEYPAD KEYBOARD INPUT
        if (keyPadText.text.Length < 4) {

            if (Input.GetKeyDown(KeyCode.Keypad1) || Input.GetKeyDown(KeyCode.Alpha1)) {

                string tempCurString = keyPadText.text;
                string tempNewString = tempCurString + "1";
                keyPadText.text = tempNewString;
				source.PlayOneShot(buttonPressed);
            }

            if (Input.GetKeyDown(KeyCode.Keypad2) || Input.GetKeyDown(KeyCode.Alpha2))
            {

                string tempCurString = keyPadText.text;
                string tempNewString = tempCurString + "2";
                keyPadText.text = tempNewString;
				source.PlayOneShot(buttonPressed);
            }

            if (Input.GetKeyDown(KeyCode.Keypad3) || Input.GetKeyDown(KeyCode.Alpha3))
            {

                string tempCurString = keyPadText.text;
                string tempNewString = tempCurString + "3";
                keyPadText.text = tempNewString;
				source.PlayOneShot(buttonPressed);
            }

            if (Input.GetKeyDown(KeyCode.Keypad4) || Input.GetKeyDown(KeyCode.Alpha4))
            {

                string tempCurString = keyPadText.text;
                string tempNewString = tempCurString + "4";
                keyPadText.text = tempNewString;
				source.PlayOneShot(buttonPressed);
            }

            if (Input.GetKeyDown(KeyCode.Keypad5) || Input.GetKeyDown(KeyCode.Alpha5))
            {

                string tempCurString = keyPadText.text;
                string tempNewString = tempCurString + "5";
                keyPadText.text = tempNewString;
				source.PlayOneShot(buttonPressed);
            }

            if (Input.GetKeyDown(KeyCode.Keypad6) || Input.GetKeyDown(KeyCode.Alpha6))
            {

                string tempCurString = keyPadText.text;
                string tempNewString = tempCurString + "6";
                keyPadText.text = tempNewString;
				source.PlayOneShot(buttonPressed);
            }

            if (Input.GetKeyDown(KeyCode.Keypad7) || Input.GetKeyDown(KeyCode.Alpha7))
            {

                string tempCurString = keyPadText.text;
                string tempNewString = tempCurString + "7";
                keyPadText.text = tempNewString;
				source.PlayOneShot(buttonPressed);
            }

            if (Input.GetKeyDown(KeyCode.Keypad8) || Input.GetKeyDown(KeyCode.Alpha8))
            {

                string tempCurString = keyPadText.text;
                string tempNewString = tempCurString + "8";
                keyPadText.text = tempNewString;
				source.PlayOneShot(buttonPressed);
            }

            if (Input.GetKeyDown(KeyCode.Keypad9) || Input.GetKeyDown(KeyCode.Alpha9))
            {

                string tempCurString = keyPadText.text;
                string tempNewString = tempCurString + "9";
                keyPadText.text = tempNewString;
				source.PlayOneShot(buttonPressed);
            }

            if (Input.GetKeyDown(KeyCode.Keypad0) || Input.GetKeyDown(KeyCode.Alpha0))
            {

                string tempCurString = keyPadText.text;
                string tempNewString = tempCurString + "0";
                keyPadText.text = tempNewString;
				source.PlayOneShot(buttonPressed);
            }
        }

        if (Input.GetKeyDown(KeyCode.Backspace)) {

            string tempGetString = keyPadText.text;
            if (tempGetString.Length > 0)
            {

                ClickBackspace();
            }
        }

        if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return)) {

            string tempPass = keyPadText.text;

            if (password == tempPass)
            {
                StartCoroutine(MyCoroutine());
                exitDoor.SetActive(false);
                source.PlayOneShot(keypadSuccess);
            }
            else
            {

                string tempString = tempPass.Substring(0, tempPass.Length - tempPass.Length);
                keyPadText.text = tempString; ;
            }
        }
            
    }
	

	void OnTriggerStay(Collider other)
	{	
		if (other.CompareTag ("Player") && playerController.havePill || _openAccess)
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
			loginInfo.enabled = true;
        }

        playerController.enabled = false;
    }
	
	public void KeyPadUnActive()
	{
		
		keyPad.enabled = false;
        idCard.enabled = false;
		loginInfo.enabled = false;
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
        idCard.enabled = false;
        loginInfo.enabled = false;
        playerController.canMove = true;
		playerController.enabled = true;
	}
}
