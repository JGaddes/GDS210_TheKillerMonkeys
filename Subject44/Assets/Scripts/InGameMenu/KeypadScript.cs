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
	public Text interactPrompt;
    public Image idCard;
	
	private Animator anim;

	
	// Use this for initialization
	void Start () {
		
		playerController.GetComponent<PlayerController>();
		anim = keyPadText.GetComponent<Animator>();

		keyPad.enabled = false;
		anim.enabled = false;
		_openAccess = false;
		interactPrompt.enabled = false;

        idCard.enabled = false;
        KeyPadUnActive();
	}

    void Update() {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            KeyPadUnActive();
        }
    }

	void OnTriggerEnter()
	{
		if(anim.enabled == false){
			if(playerController.havePill)
			{
				interactPrompt.enabled = true;
			}
		}
	}

	void OnTriggerStay(Collider other){

		if(Input.GetKeyDown(KeyCode.E))
		{
			interactPrompt.enabled = false;
			if (other.CompareTag ("Player") && playerController.havePill || _openAccess == true )
			{
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
        KeyPadUnActive();
	}
	
	public void ClickLetter(string letterClicked)
	{
		if (keyPadText.text.Length < 4) {
			string tempCurString = keyPadText.text;
			string tempNewString = tempCurString + letterClicked;
			keyPadText.text = tempNewString;
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
