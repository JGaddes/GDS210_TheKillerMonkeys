using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class CheckIfDead : MonoBehaviour {

    public GameObject guard1;
    public GameObject guard2;
    public GameObject guard3;

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


    // Use this for initialization
    void Start () {

        //disable the image component of all the star images
        star1.GetComponent<Image>().enabled = false;
        star2.GetComponent<Image>().enabled = false;
        star3.GetComponent<Image>().enabled = false;

        //disable the next button
        buttonNext.SetActive(false);

        //save the current level name
        currentLevel = Application.loadedLevelName;
    }
	
	// Update is called once per frame
	void Update () {

        if (guard1 == null && guard2 == null && guard3 == null) {

            isLevelComplete = true;
            if (totalTime < 30)
            {
                star3.GetComponent<Image>().enabled = true;
                UnlockLevels(3);   //unlock next level function 
            }
            else if (totalTime < 60)
            {
                star2.GetComponent<Image>().enabled = true;
                UnlockLevels(2);   //unlock next level function 
            }
            else if (totalTime > 60)
            {
                star1.GetComponent<Image>().enabled = true;
                UnlockLevels(1);   //unlock next level function 
            }
            buttonNext.SetActive(true);

            Time.timeScale = 0;          
        }

        //update the timer value
        totalTime += Time.deltaTime;

        //display the timer value 
        timerText.text = "TIME: " + totalTime.ToString("0.");
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
