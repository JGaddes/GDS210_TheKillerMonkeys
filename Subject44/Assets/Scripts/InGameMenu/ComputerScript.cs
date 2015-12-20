using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class ComputerScript : MonoBehaviour {

    //Reference to other Scripts
    public PlayerController _playerController;
    public ChildCollider _childCollider;
	public PauseMenuScript _pauseMenuScript;

    public bool _openAccess;
    public Image idCard;
    public bool compStopMove;

	private Text popUpText;

    public GameObject[] lockedDoors;
    //public GameObject[] unlockedDoors;
    public GameObject[] secCams;
    public SecCamAi secCamAi;
    public Animator anim;


	public AudioClip loginFail, loginSuccess; 
	public AudioSource source; 

    // Use this for initialization
    void Start () {
        lockedDoors = GameObject.FindGameObjectsWithTag("Locked Door");
        //unlockedDoors = GameObject.FindGameObjectsWithTag("Unlocked Door");
        secCams = GameObject.FindGameObjectsWithTag("Sec Cam");
		popUpText = _playerController.gameObject.GetComponent<PlayerController> ().interactText;


        anim.enabled = false;
        _openAccess = false;
        idCard.enabled = false;


        //foreach (GameObject ud in unlockedDoors) {

        //    ud.SetActive(false);
        //}
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Escape)) {
            ComputerUnActive();
        }
	
	}

    void OnTriggerEnter(Collider col) {
		if (_playerController.havePill && !_playerController.bananananaMode) {
			popUpText.enabled = true;
		}
    }

    void OnTriggerStay(Collider other)
    {

        if (Input.GetKeyDown(KeyCode.E))
        {

			popUpText.enabled = false;

            if (other.CompareTag("Player") && _playerController.havePill )
            {

                ComputerActive();

            }
			else
			{
				source.PlayOneShot(loginFail); 
			}
        }
    }

    void OnTriggerExit(Collider other) {

        if (other.gameObject.tag == "Player")
        {
            ComputerUnActive();
			popUpText.enabled = false;
        }
    }

    public void ComputerActive(){

		if (!_playerController.bananananaMode) {

			if (_childCollider.haveIdCard == true) {

				source.PlayOneShot(loginSuccess); 
                UnlockDoors();
                DisableCameras();
                _playerController.pillCount -= 1;
                anim.enabled = true;
                
            }
		}       
    }

    public void ComputerUnActive()
    {

        _playerController.enabled = true;
		_pauseMenuScript.enabled = true;
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

        //foreach (GameObject ud in unlockedDoors)
        //{

        //    ud.SetActive(true);
        //}
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
