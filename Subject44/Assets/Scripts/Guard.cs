using UnityEngine;
using System.Collections;

public class Guard : MonoBehaviour {

	public GameObject player;
	public PlayerController playerController;

	// Use this for initialization
	void Start () 
	{

		playerController = player.GetComponent<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Vector3.Distance (transform.position, player.transform.position) < 1.5f) {
<<<<<<< HEAD
			if(playerController.isBanana){
				if(Input.GetKeyDown(KeyCode.Mouse0)) {
					Destroy (gameObject);
				}
=======
			if(Input.GetKeyDown(KeyCode.Mouse0)) {
				Destroy (gameObject);
>>>>>>> origin/master
			}
		}
	}
}
