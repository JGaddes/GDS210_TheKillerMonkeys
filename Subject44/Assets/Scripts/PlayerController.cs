using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour {

	// Public Variables
	public float speed = 5f;
	public float bananaTime = 15f;
	public float pillCount = 0f;
    public float bananaCount = 0f;
	public float colCount;

	public Vector3 spawnPoint;
	public AudioClip levelfinish;
	AudioSource source;
	public AudioSource cameraSource; 
	
	public bool onPole = false;
    public bool inBarrel = false;
    public bool hidden = false;
	public bool useBanana = false;
	public bool havePill = false;
    public bool canMove = true;
	public bool bananananaMode = false;
	public bool stand = true;

    public CharacterController controller;
	public Slider bananaSlider;
    private Vector3 moveDirection = Vector3.zero;
	public Text interactText;

	public Animator MonkeyAnimator;

    //GUI VARIABLES!!
    //public GuiScript guiScript;

    //reference to stars
    public Image star1;
    public Image star2;
    public Image star3;
	
    //reference to next button
    public GameObject buttonNext;

    private string currentLevel;
    private int worldIndex;
    private int levelIndex;
    private bool isLevelComplete;

    //timer text reference
    public Text timerText;
	
    //time passed since start of level
    protected float totalTime = 0f;

	public Image banana;
    public Image pill;
    public Image key;
    public Text pillAmountText;
    public Text bananaAmountText;
    public Text keyAmountText;
	public Image collect1, collect2, collect3;

	public GameObject[] _secCameraView;

    void Start () {
		interactText.enabled = false;

		//sets the player's spawnpoint 
		spawnPoint = new Vector3(transform.position.x, transform.position.y, transform.position.z);

		//set the level complete to false on start of level
        isLevelComplete = false;

        //disable the image component of all the star images
        star1.GetComponent<Image>().enabled = false;
        star2.GetComponent<Image>().enabled = false;
       	star3.GetComponent<Image>().enabled = false;

        //disable the next button
        buttonNext.SetActive(false);

        //save the current level name
        currentLevel = Application.loadedLevelName;
		
		//guiScript.GetComponent <GuiScript>();
		controller = GetComponent<CharacterController> ();
		useBanana = false;
		bananaSlider.value = 0;
        pillCount = 0;

		//MonkeyAnimator.SetInteger ("Walk", 1);

		source = GetComponent<AudioSource> ();

		foreach (GameObject sc in _secCameraView) {
			sc.SetActive(false);
		}

		stand = true;

	}


	void Update () {

		//Monkey Animation

		if (Input.GetKey(KeyCode.W))
		{
			stand = false;
		}

		if (Input.GetKey(KeyCode.A))
		{
			stand = false;
		}

		if (Input.GetKey(KeyCode.S))
		{
			stand = false;
		}

		if (Input.GetKey(KeyCode.D))
		{
			stand = false;
		}


		if (Input.GetKeyUp(KeyCode.W))
		{
			stand = true;
		}
		
		if (Input.GetKeyUp(KeyCode.A))
		{
			stand = true;
		}
		
		if (Input.GetKeyUp(KeyCode.S))
		{
			stand = true;
		}
		
		if (Input.GetKeyUp(KeyCode.D))
		{
			stand = true;
		}


		if (hidden)
		{
			MonkeyAnimator.SetBool("Hidden", true);
			MonkeyAnimator.SetBool("StandHidden", false);

			if(stand)
			{
				MonkeyAnimator.SetBool("StandHidden", true);
			}
		}

		if (!hidden)
		{
			MonkeyAnimator.SetBool("Hidden", false);
			MonkeyAnimator.SetBool("Stand", false);

			if(stand)
			{
				MonkeyAnimator.SetBool("Stand", true);
			}
		}

		if (bananananaMode)
		{
			bananaSlider.value -= bananaTime * Time.deltaTime;
			speed = 7.5f;
			MonkeyAnimator.SetBool("Banana", true);
			MonkeyAnimator.SetBool("StandBanana", false);

			if(stand)
			{
				MonkeyAnimator.SetBool("StandBanana", true);
				MonkeyAnimator.SetBool("Stand", false);

			}
		}

		if (!bananananaMode)
		{
			useBanana = false;
			MonkeyAnimator.SetBool("Banana", false);
			MonkeyAnimator.SetBool("StandBanana", false);
			speed = 5f;
			bananaTime = 15f;
		}

        controller = GetComponent<CharacterController>();

        if (canMove)
        {
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            controller.Move(moveDirection * Time.deltaTime);
        }
     

        if (pillCount > 0) {
			havePill = true;
            pill.canvasRenderer.SetAlpha(1);
        }

		if (pillCount == 0) {
            pill.canvasRenderer.SetAlpha(0.2f);
        }

        if (bananaCount > 0)
		{
            if (!useBanana)
            {
				banana.canvasRenderer.SetAlpha(1f);
                if (Input.GetKeyDown(KeyCode.B))
                {
					bananaSlider.value = 100;
                    bananaCount -= 1;
                    useBanana = true;
                    hidden = false;
                }
            }               
		}

        if (bananaCount == 0)
        {
            banana.canvasRenderer.SetAlpha(0.1f);
        }

        if (useBanana)
        {
			bananananaMode = true;
        }

		if (bananaSlider.value <= 0)
		{
			bananananaMode = false;
        }

        bananaAmountText.text = ("x " + bananaCount);
        pillAmountText.text = ("x " + pillCount);

        if (pillCount == 0) {

            havePill = false;
        }
		
	}


	void OnTriggerEnter(Collider col)
    {
		if (col.gameObject.name == "Goal")
        { 
            //set the isLevelComplete flag to true if the player hits an object with name Goal
            isLevelComplete = true;
            if (totalTime < 2)
            {
                star3.GetComponent<Image>().enabled = true;
                UnlockLevels(3);   //unlock next level function 
            }
            else if (totalTime < 5)
            {
                star2.GetComponent<Image>().enabled = true;
                UnlockLevels(2);   //unlock next level function 
            }
            else if (totalTime > 5)
            {
                star1.GetComponent<Image>().enabled = true;
                UnlockLevels(1);   //unlock next level function 
            }
            buttonNext.SetActive(true);
            Time.timeScale = 0;

			source.PlayOneShot(levelfinish);
			cameraSource.volume = 0.1f; 
        }
    }

	 public void OnClickButton()
    {
        //load the World1 level 
        Application.LoadLevel("MainMenu1");

    }
	
	public void UnlockLevels(int stars)
    {
        //set the playerprefs value of next level to 1 to unlock
        for (int i = 0; i < LockLevel.worlds; i++)
        {
            for (int j = 1; j < LockLevel.levels; j++)
            {
                if (currentLevel == "Level" + (i + 1).ToString() + "." + j.ToString())
                {
                    worldIndex = (i + 1);
                    levelIndex = (j + 1);
                    PlayerPrefs.SetInt("level" + worldIndex.ToString() + ":" + levelIndex.ToString(), 1);

                    //check if the current stars value is less than the new value
                    if (PlayerPrefs.GetInt("level" + worldIndex.ToString() + ":" + j.ToString() + "stars") < stars)

                        //overwrite the stars value with the new value obtained
                        PlayerPrefs.SetInt("level" + worldIndex.ToString() + ":" + j.ToString() + "stars", stars);
                }
            }
        }
    }
}