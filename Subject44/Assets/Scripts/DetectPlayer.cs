using UnityEngine;
using System.Collections;

public class DetectPlayer : MonoBehaviour {

	//public RaycastHit hit;
	
	public GameObject player;
	public PlayerController playerController;
	
	public float fieldOfView = 0f;
	public float rayRange = 0f;

	private Vector3 rayDirection;

	public AudioClip detected; 
	public AudioSource source; 
	
	
	// Use this for initialization
	void Start () 
	{
		playerController = player.GetComponent<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		CanSeePlayer ();
		PlayerDetected();
	}
	
	bool CanSeePlayer() {
		
		RaycastHit hit;
		var rayDirection = player.transform.position - transform.position;
		
		if((Vector3.Angle(rayDirection, transform.forward)) <= fieldOfView){ // Detect if player is within the field of view
			if (Physics.Raycast (transform.position, rayDirection, out hit, rayRange)) {
				
				if (hit.transform.tag == "Player") {
					return true;
				}else{
					return false;
				}
			}
		}
		return false;
	}

	void OnDrawGizmosSelected ()
	{
		var rayDirection = transform.forward;
		Quaternion rl = Quaternion.AngleAxis(fieldOfView / 2, transform.up);
		Quaternion rr = Quaternion.AngleAxis(-fieldOfView / 2, transform.up);

		Debug.DrawRay (transform.position,rayDirection * rayRange, Color.green);
		Debug.DrawRay (transform.position, rl * rayDirection * rayRange, Color.red);
		Debug.DrawRay (transform.position, rr * rayDirection * rayRange, Color.red);

	}
	
	void PlayerDetected()
	{
		if (CanSeePlayer()) 
		{
			if (!playerController.hidden) 
			{
				playerController.speed = 0f;
				playerController.useBanana = false;
				playerController.bananananaMode = false;
				playerController.bananaSlider.value = 0f;
				player.transform.position = player.GetComponent<PlayerController>().spawnPoint;
				player.transform.eulerAngles = new Vector3 (0, 0, 0);
				source.PlayOneShot(detected);
			}
		}
	}
}