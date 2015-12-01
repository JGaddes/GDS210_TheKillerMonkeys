using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainPicturePopUp : MonoBehaviour {
	
	public Image picture, pictureBack;
	public Text interactText;
	
	// Use this for initialization
	void Start() {
		
		picture.enabled = false;
		pictureBack.enabled = false;
		interactText.enabled = false;
		
	}
	
	// Update is called once per frame
	void Update() {
		
	}
	
	void OnTriggerStay()
	{
		
		interactText.enabled = true;
		
		if (Input.GetKey(KeyCode.E))
		{
			interactText.enabled = false;
			picture.enabled = true;
			pictureBack.enabled = true;
		}
	}
	
	void OnTriggerExit() {
		
		picture.enabled = false;
		pictureBack.enabled = false;
		interactText.enabled = false;
	}
}
