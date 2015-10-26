using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

	// Public Variables
	public float speed = 15f;
	public float lookSpeed;
	public float bCldn = 5f; //banana mode cooldown
	public float vCldn = 0.5f; //vent cooldown

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
	public Slider bananaSlider;


	void Start () {

		//guiScript.GetComponent <GuiScript>();
		controller = GetComponent<CharacterController> ();
		isBanana = false;
	}


	void Update () {

		TestHidden ();

		float _vert = -Input.GetAxis("Vertical");
		float _hori = -Input.GetAxis ("Horizontal");
		
		Vector3 _moveDirection = transform.TransformDirection (_hori, 0, _vert).normalized; 
		controller.SimpleMove(((_moveDirection * speed) * Time.deltaTime) * speed);
		_moveDirection = Vector3.zero;
	}


	void OnTriggerStay (Collider other)
	{
		if (other.CompareTag("Detect"))
		{
			if (hidden == false){
				speed = 0f;
				transform.position = new Vector3(8, 0.5f, -2);
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
			
			Debug.Log ("Mmmm nana");
			//guiScript.bananaList[0].SetActive (true);
			Destroy(col.gameObject);
		}
    }

	void OnTriggerExit(Collider other){
		if (other.CompareTag ("Shadow")) {
			hidden = false;
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
            Debug.Log("No more hidde");
		}

	}


	public void BananaMode(){
		GameObject[] shadow = GameObject.FindGameObjectsWithTag ("Shadow");

		while (bananaSlider.value > 0) {
			isBanana = true;
			hidden = false;
			//gameObject.GetComponent<Renderer> ().material = bananaMode;
			foreach (GameObject _obj in shadow) {
				_obj.SetActive (false);
			}
		}


		/*if (bananaSlider.value == 0){
			isBanana = false;
			gameObject.GetComponent<Renderer> ().material = visible;
			foreach (GameObject _obj in shadow) {
				_obj.SetActive (true);
			}*/
	
	}
}