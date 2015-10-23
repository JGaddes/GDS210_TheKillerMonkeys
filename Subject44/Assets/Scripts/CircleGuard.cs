using UnityEngine;
using System.Collections;

public class CircleGuard : MonoBehaviour {

	public GameObject player;
	public BoxCollider guardColl;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Vector3.Distance (transform.position, player.transform.position) < 2f)
		{
			if(Input.GetKeyDown(KeyCode.LeftShift))
			{
				guardColl.enabled = false;
				player.transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
				player.GetComponent<PlayerController>().speed = 15f;
				player.GetComponent<PlayerController>().onPole = false;
				player.GetComponent<PlayerController>().hidden = false;
				Destroy (gameObject);
			}
		}

	}
}
