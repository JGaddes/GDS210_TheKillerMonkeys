﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour {

	// Public Variables
	public float speed = 5f;
	public float bananaTime = 15f;
	public float pillCount = 0f;
    public float bananaCount = 0f;

	public AudioClip bananaMusic;
	public AudioClip levelfinish;
	AudioSource source;
	
	public bool onPole = false;
    public bool inBarrel = false;
    public bool hidden = false;
	public bool useBanana = false;
	public bool havePill = false;
    public bool canMove = true;
	public bool bananananaMode = false;

    //public GameObject playerSprite;
    //public GameObject playerVisible;
   // public GameObject playerHidden;
    public GameObject shadows;

    public CharacterController controller;
	public Slider bananaSlider;
	public AudioClip detected, enemyDeath;
    private Vector3 moveDirection = Vector3.zero;

	public Animator MonkeyAnimator;

    //GUI VARIABLES!!
    public GuiScript guiScript;

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



    void Start () {
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
		
		guiScript.GetComponent <GuiScript>();
		controller = GetComponent<CharacterController> ();
		useBanana = false;
		bananaSlider.value = 0;
        pillCount = 0;

		MonkeyAnimator.SetInteger ("Walk", 1);

		source = GetComponent<AudioSource> ();

	}


	void Update () {

		//Monkey Animation
		if (hidden)
		{
			MonkeyAnimator.SetBool("Hidden", true);
		}

		if (!hidden)
		{
			MonkeyAnimator.SetBool("Hidden", false);
		}

		if (bananananaMode)
		{
			MonkeyAnimator.SetBool("Banana", true);
		}

		if (!bananananaMode)
		{
			MonkeyAnimator.SetBool("Banana", false);
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

		if (!isLevelComplete)
        {
            //update the timer value
            totalTime += Time.deltaTime;

            //display the timer value 
            timerText.text = "TIME: " + totalTime.ToString();
        }

		if (bananaCount > 0)
		{
            if (!useBanana)
            {
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
			bananaSlider.value -= bananaTime * Time.deltaTime;
            speed = 7.5f;
			bananananaMode = true;
        }

		if (bananaSlider.value <= 0)
		{
            useBanana = false;
            speed = 5;
			bananaTime = 15f;
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
        }

        if (col.gameObject.tag == "KeyPad")
        {
            if (havePill == true)
            {
                guiScript.KeyPadActive();
                //pills -= 1;
            }
        }

        if (col.gameObject.tag == "Computer")
        {

            guiScript.ComputerActive();
            speed = 0;
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


	/*void TestHidden()
	{
        // Switches spritesheet when hidden / visible
		if (hidden)
        {
            playerVisible.SetActive(false);
            playerHidden.SetActive(true);
		}

        else
        {
            playerVisible.SetActive(true);
            playerHidden.SetActive(false);
		}

	}*/
}