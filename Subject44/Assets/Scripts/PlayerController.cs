using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

	// Public Variables
	public float speed = 10f;
	public float lookSpeed;
	public float bCldn = 5f; //banana mode cooldown
	public float vCldn = 0.5f; //vent cooldown
	public float bananaTime = 15f;

	public AudioClip bananaMusic;

	public bool onPole = false;
	public bool hidden = false;
	public bool isBanana = false;


	//public Material hide;
	//public Material visible;
	//public Material bananaMode;

	public CharacterController controller;

	//public GuiScript guiScript;
	public Vent vent;
<<<<<<< HEAD
	public GameObject playerSprite;
=======
	public Slider bananaSlider;
	public GameObject playerSprite;

	public AudioClip detected, enemyDeath;

>>>>>>> origin/master

	public AudioClip detected, enemyDeath;
	
	//GUI VARIABLES!!
	public GuiScript guiScript;


    //reference to stars
    private GameObject star1;
    private GameObject star2;
    private GameObject star3;

    //reference to next button
    private GameObject buttonNext;

    private string currentLevel;
    private int worldIndex;
    private int levelIndex;

    bool isLevelComplete;

    //timer text reference
    public Text timerText;

    //time passed since start of level
    protected float totalTime = 0f;

	public Image banana;



	void Start () {
		//set the level complete to false on start of level
        isLevelComplete = false;
        //get the star images
        star1 = GameObject.Find("star1");
        star2 = GameObject.Find("star2");
        star3 = GameObject.Find("star3");
        //get the next button
        buttonNext = GameObject.Find("Next");
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
		isBanana = false;
<<<<<<< HEAD

		banana.canvasRenderer.SetAlpha (0);
=======
>>>>>>> origin/master
		
	}


	void Update () {

		TestHidden ();

		float _vert = -Input.GetAxis("Vertical");
		float _hori = -Input.GetAxis ("Horizontal");
		
		Vector3 _moveDirection = transform.TransformDirection (_hori, 0, _vert).normalized; 
		controller.SimpleMove(((_moveDirection * speed) * Time.deltaTime) * speed);
		_moveDirection = Vector3.zero;

<<<<<<< HEAD
		if (!isLevelComplete)
        {
            //update the timer value
            totalTime += Time.deltaTime;
            //display the timer value 
            timerText.text = "TIME: " + totalTime.ToString();

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.LoadLevel("MainMenu1");
            }
        }

		if (isBanana)
		{
			bananaTime -= Time.deltaTime;
			banana.canvasRenderer.SetAlpha(100);
		}

		if (bananaTime <= 0)
		{
			isBanana = false;
			bananaTime = 15f;
			banana.canvasRenderer.SetAlpha(0);
		}
=======
>>>>>>> origin/master

	}


	void OnTriggerStay (Collider other)
	{
		if (other.CompareTag("Detect"))
		{
			if (hidden == false){
				speed = 0f;
				transform.position = new Vector3(6.46f, 0.171f, 0.4f);
				playerSprite.transform.eulerAngles = new Vector3(90, 0, 0);
				speed = 15f;
			}
		}

		if (other.CompareTag ("Shadow")) {
			hidden = true;	
		}

        if (other.CompareTag("Vent"))
        {
            vent.CallVent();
        }
	}
	

	void OnTriggerEnter(Collider col){

		if (col.CompareTag("Banana")){
<<<<<<< HEAD

			isBanana = true;

=======
>>>>>>> origin/master
			
			Debug.Log ("Mmmm nana");
			//guiScript.bananaList[0].SetActive (true);
			Destroy(col.gameObject);
		}
<<<<<<< HEAD
		
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

        }
		
		 if (col.gameObject.tag == "KeyPad") {
 
            guiScript.KeyPadActive();
        }
		
		
=======
>>>>>>> origin/master
    }

	void OnTriggerExit(Collider other){
		if (other.CompareTag ("Shadow")) {
			hidden = false;
		}
		
		if (other.gameObject.tag == "KeyPad")
        {

            guiScript.KeyPadUnActive();
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


	void TestHidden()
	{
		if (hidden == true)
        {
            //gameObject.GetComponent<Renderer> ().material = hide;
            Debug.Log("u r know hidde");
		}

        else
        {
            //gameObject.GetComponent<Renderer> ().material = visible;
            //Debug.Log("No more hidde");
		}

	}


	public void BananaMode(){
		//GameObject[] shadow = GameObject.FindGameObjectsWithTag ("Shadow");

		isBanana = true;
		hidden = false;
			//gameObject.GetComponent<Renderer> ().material = bananaMode;
			//foreach (GameObject _obj in shadow) {
				//_obj.SetActive (false);
			//}
		}


		/*if (bananaSlider.value == 0){
			isBanana = false;
			gameObject.GetComponent<Renderer> ().material = visible;
			foreach (GameObject _obj in shadow) {
				_obj.SetActive (true);
			}*/
}