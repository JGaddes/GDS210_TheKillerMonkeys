using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class ComputerScript : MonoBehaviour {

    //Reference to other Scripts
    public PlayerController _playerController;
    public ChildCollider _childCollider;

    public Text compInput;
    public Canvas Computer;
    public string loginPass = "";
    public bool _openAccess;
    public Text interactPrompt;
    public Image idCard;
    public bool compStopMove;

    private Animator anim2;

    public GameObject[] lockedDoors;
    public GameObject[] secCams;
    public SecCamAi secCamAi;

    // Use this for initialization
    void Start () {

        lockedDoors = GameObject.FindGameObjectsWithTag("Locked Door");
        secCams = GameObject.FindGameObjectsWithTag("Sec Cam");

        anim2 = Computer.gameObject.GetComponent<Animator>();
        Computer.enabled = false;
        anim2.enabled = false;
        _openAccess = false;
        interactPrompt.enabled = false;
        idCard.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Escape)) {
            ComputerUnActive();
        }
	
	}

    void OnTriggerEnter(Collider col) {

        interactPrompt.enabled = true;       
    }

    void OnTriggerStay(Collider other)
    {

        if (Input.GetKeyDown(KeyCode.E))
        {

            interactPrompt.enabled = false;

            if (other.CompareTag("Player") && _playerController.havePill || _openAccess == true)
            {

                ComputerActive();

                if (_openAccess == false)
                {

                    _openAccess = true;
                    _playerController.pillCount -= 1;
                }
            }
            else { Debug.Log("No pills"); }
        }
    }

    void OnTriggerExit(Collider other) {

        if (other.gameObject.tag == "Player")
        {
            ComputerUnActive();
            interactPrompt.enabled = false;
        }
    }

    public void CodeCheck(string other)
    {

        string tempLogin = compInput.text.ToLower();

        if (loginPass == tempLogin)
        {

            Debug.Log("Correct Pass");
            anim2.enabled = true;
            _playerController._secCameraView.SetActive(true);
        }
        else
        {

            Debug.Log("Wrong pass");
        }
    }

    public void ComputerActive()
    {
		if (!_playerController.bananananaMode) {
			_playerController.enabled = false;
			Computer.enabled = true;
			_playerController._secCameraView.SetActive (true);
        

			if (_childCollider.haveIdCard == true) {
				_childCollider.idCard.SetActive (false);
				idCard.enabled = true;
			}
		}
        
    }

    public void ComputerUnActive()
    {
        Computer.enabled = false;
        _playerController._secCameraView.SetActive(false);
        _playerController.enabled = true;
        idCard.enabled = false;
		if (_childCollider.haveIdCard == true) {

			_childCollider.idCard.SetActive(true);
		}

    }

    public void UnlockDoors()
    {
        //lockedDoors[].SetActive(false);
        foreach (GameObject d in lockedDoors)
        {
            d.SetActive(false);
            Debug.Log("Doors Unlocking!");
        }
    }

    public void DisableCameras()
    {
        foreach (GameObject sc in secCams)
        {
            secCamAi.GetComponent<SecCamAi>().activated = false;
            sc.GetComponentInChildren<ParticleSystem>().enableEmission = false;
            sc.GetComponentInChildren<DetectPlayer>().enabled = false;
        }
        Debug.Log("Cameras Disabled!");
    }
}
