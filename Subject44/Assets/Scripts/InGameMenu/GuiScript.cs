using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class GuiScript : MonoBehaviour {
	
	//public Slider bananaMode;
	public PlayerController playerController;
	//public List<GameObject> bananaList;
	//public Slider bananaSlider;

	public int count;
	public float cooldown = 2;

    //KepPad Variables
    public Text keyPadText;
    public Canvas keyPad;
    public string password = "";

    private Animator anim;


    // Use this for initialization
    void Start () {
	
		playerController.GetComponent <PlayerController>();
		//bananaSlider.value = 0;

        
        anim = keyPadText.GetComponent<Animator>();
        keyPad.enabled = false;
        anim.enabled = false;
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
            Debug.Log("Unlocking something!");
            //THIS IS WHERE YOU CAN MAKE IT OPEN A DOOR ETC!
            
        }
        else {

            Debug.Log("Wrong code, try again");
            string tempString = tempPass.Substring(0, tempPass.Length - tempPass.Length);
            keyPadText.text = tempString;
        }
    }

    public void KeyPadActive() {

        keyPad.enabled = true;
    }

    public void KeyPadUnActive()
    {

        keyPad.enabled = false;
    }

    IEnumerator MyCoroutine(){

        //Disable Raycast so the Keypad becomes unusable
        keyPad.GetComponent<GraphicRaycaster>().enabled = false;
        anim.enabled = true;
        yield return new WaitForSeconds(2);
        keyPad.enabled = false;
    }
}