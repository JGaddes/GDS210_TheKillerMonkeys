using UnityEngine;
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

    public GameObject exitDoor;

    //Computer Variables
    public Text compInput;
    public Canvas Computer;
    public string loginPass = "";

    private Animator anim2;
    private Animator anim;

	AudioSource KeyPressed; 
	AudioSource PasswordSuccess; 
	AudioSource PasswordFail;

    public GameObject[] lockedDoors;
    public GameObject[] secCams;
    public SecCamAi secCamAi;


    // Use this for initialization
    void Start () {

        lockedDoors = GameObject.FindGameObjectsWithTag("Locked Door");
        secCams = GameObject.FindGameObjectsWithTag("Sec Cam");

        playerController.GetComponent<PlayerController>();        
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

    public void CodeCheck(string other) {

		string tempLogin = compInput.text;

       // switch (other.ToLower()){

        //    case "password":
         //       Debug.Log("Correct Password");
         //       anim2.enabled = true;
           //     break;
          //  default:
           //     Debug.Log("Wrong Code Nerd!");
            //    break;
      //  }

		if (loginPass == tempLogin) {

			Debug.Log ("Correct Pass");
			anim2.enabled = true;
		} else {
		
			Debug.Log ("Wrong pass");
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
            playerController.canMove = true;
            exitDoor.SetActive(false);

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
        playerController.canMove = false;
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
        playerController.canMove = false;
    }

    public void ComputerUnActive()
    {
        Computer.enabled = false;
        playerController.canMove = true;
    }

    public void UnlockDoors()
    {

        Debug.Log("Doors Unlocking!");
        foreach (GameObject d in lockedDoors)
        {
            d.SetActive(false);
        }
    }

    public void DisableCameras()
    {
        foreach (GameObject sc in secCams)
        {
            secCamAi.GetComponent<SecCamAi>().activated = false;
            sc.GetComponentInChildren<MeshCollider>().enabled = false;
            sc.GetComponentInChildren<MeshRenderer>().enabled = false;
        }
        Debug.Log("Cameras Disabled!");
    }

    //END OF COMPUTER FUNCTIONS

    
}