using UnityEngine;
using System.Collections;

public class ChildCollider : MonoBehaviour {

	public PlayerController player;
	public AudioSource source;
	public AudioClip detected;

	// Use this for initialization
	void Start () {

		player = gameObject.GetComponentInParent<PlayerController> ();
		source = gameObject.GetComponentInParent<AudioSource> ();
		detected = gameObject.GetComponentInParent<PlayerController>().detected;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay (Collider other)
	{
		if (other.CompareTag("Detect"))
		{
			if (player.hidden == false){
				player.speed = 0f;
				player.transform.position = new Vector3(6.46f, 0.171f, 0.4f);
				player.transform.eulerAngles = new Vector3(90, 0, 0);
				player.speed = 15f;
			}
		}
		
		if (other.CompareTag ("Shadow")) {
			player.hidden = true;	
		}
		
		if (other.CompareTag("Vent"))
		{
			player.vent.CallVent();
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
			player.hidden = false;
		}
	}

}
