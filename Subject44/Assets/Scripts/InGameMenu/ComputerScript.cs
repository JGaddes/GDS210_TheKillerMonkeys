using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class ComputerScript : MonoBehaviour {

    //Reference to other Scripts
    public PlayerController _playerController;
    public ChildCollider _childCollider;
	public PauseMenuScript _pauseMenuScript;

    public Text compInput;
    public Canvas Computer;
    public string loginPass = "";
    public bool _openAccess;
    public Image idCard;
    public bool compStopMove;

    private Animator anim2;
	private Text popUpText;

    public GameObject[] lockedDoors;
    public GameObject[] secCams;
    public SecCamAi secCamAi;

    // Use this for initialization
    void Start () {
        lockedDoors = GameObject.FindGameObjectsWithTag("Locked Door");
        secCams = GameObject.FindGameObjectsWithTag("Sec Cam");
		popUpText = _playerController.gameObject.GetComponent<PlayerController> ().interactText;

        anim2 = Computer.gameObject.GetComponent<Animator>();
        Computer.enabled = false;
        anim2.enabled = false;
        _openAccess = false;
        idCard.enabled = false;
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

            if (other.CompareTag("Player") && _playerController.havePill || _openAccess == true)
            {

                ComputerActive();

                if (_openAccess == false)
                {

                    _openAccess = true;
                    _playerController.pillCount -= 1;
                }
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

    public void CodeCheck(string other)
    {

        string tempLogin = compInput.text.ToLower();

        if (loginPass == tempLogin)
        {
            anim2.enabled = true;
            _playerController._secCameraView[0].SetActive(true);
			_playerController._secCameraView[1].SetActive(true);
        }
    }

    public void ComputerActive()
    {
		if (!_playerController.bananananaMode) {
			_playerController.enabled = false;
			_pauseMenuScript.enabled = false;
			Computer.enabled = true;
			_playerController._secCameraView[0].SetActive (true);
			_playerController._secCameraView[1].SetActive (true);
        

			if (_childCollider.haveIdCard == true) {
				_childCollider.idCard.SetActive (false);
				idCard.enabled = true;
			}
		}
        
    }

    public void ComputerUnActive()
    {
        Computer.enabled = false;
        _playerController._secCameraView[0].SetActive(false);
		_playerController._secCameraView[1].SetActive(false);
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
