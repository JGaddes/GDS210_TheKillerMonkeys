using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Barrel : MonoBehaviour {

	public GameObject checkUp;
	public GameObject checkDown;
	public GameObject checkLeft;
	public GameObject checkRight;
    public GameObject player;


	private Text popUpText;
	private float cooldown = 0.15f;
	private bool canUseBarrel = true;


	void Start()
	{
		popUpText = player.gameObject.GetComponent<PlayerController> ().interactText;
	}

	void Update()
	{
		if (Vector3.Distance (player.transform.position, transform.position) < 2f) {
			if (player.GetComponent<PlayerController> ().inBarrel == false) {
				if (Input.GetKey (KeyCode.E)) {
					if (canUseBarrel) {
						player.transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
						player.GetComponent<PlayerController> ().hidden = true;
						player.GetComponent<PlayerController> ().canMove = false;
						player.GetComponent<PlayerController> ().inBarrel = true;
					}
				}
			}
		}
		
		if (player.GetComponent<PlayerController> ().inBarrel) {
			if (Input.GetKeyDown (KeyCode.W)) {
				if (!checkUp.GetComponent<BarrelCollideCheck> ().isCollide) {
					if (canUseBarrel) {
						player.GetComponent<PlayerController> ().hidden = false;
						player.transform.position = checkUp.transform.position;
						player.GetComponent<PlayerController> ().canMove = true;
						player.GetComponent<PlayerController> ().inBarrel = false;
					}
				}
			}
			if (Input.GetKeyDown (KeyCode.S)) {
				if (!checkDown.GetComponent<BarrelCollideCheck> ().isCollide) {
					if (canUseBarrel) {
						player.GetComponent<PlayerController> ().hidden = false;
						player.transform.position = checkDown.transform.position;
						player.GetComponent<PlayerController> ().canMove = true;
						player.GetComponent<PlayerController> ().inBarrel = false;
					}
				}
			}
			if (Input.GetKeyDown (KeyCode.A)) {
				if (!checkLeft.GetComponent<BarrelCollideCheck> ().isCollide) {
					if (canUseBarrel) {
						player.GetComponent<PlayerController> ().hidden = false;
						player.transform.position = checkLeft.transform.position;
						player.GetComponent<PlayerController> ().canMove = true;
						player.GetComponent<PlayerController> ().inBarrel = false;
					}
				}
			}
			if (Input.GetKeyDown (KeyCode.D)) {
				if (!checkRight.GetComponent<BarrelCollideCheck> ().isCollide) {
					if (canUseBarrel) {
						player.GetComponent<PlayerController> ().hidden = false;
						player.transform.position = checkRight.transform.position;
						player.GetComponent<PlayerController> ().canMove = true;
						player.GetComponent<PlayerController> ().inBarrel = false;
					}
				}
			}
		}
	}
	
	void OnTriggerStay(Collider other)
	{
		if (other.CompareTag ("Player") && (!player.GetComponent<PlayerController> ().inBarrel)) {
			popUpText.enabled = true;
		} else 
		{
			popUpText.enabled = false;
		}
	}

	void OnTriggerExit()
	{
		popUpText.enabled = false;
	}
}
