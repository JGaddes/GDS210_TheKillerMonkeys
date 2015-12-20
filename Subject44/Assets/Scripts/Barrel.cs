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
	private float cooldown = 0.2f;
	private bool canUseBarrel = true;


	void Start()
	{
		popUpText = player.gameObject.GetComponent<PlayerController> ().interactText;

        player = GameObject.FindGameObjectWithTag ("Player");
	}



	void Update()
	{
		if (Vector3.Distance (player.transform.position, transform.position) < 2f) {
			if (canUseBarrel) {
				if (!player.GetComponent<PlayerController> ().inBarrel) {
					if (Input.GetKeyDown (KeyCode.E)) {
						player.GetComponent<PlayerController> ().inBarrel = true;
						player.transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
						player.GetComponent<PlayerController> ().canMove = false;
						StartCoroutine(BarrelCldn());
					}
				} 
				else if (player.GetComponent<PlayerController> ().inBarrel) {
					if (Input.GetKeyDown (KeyCode.W)) {
						if (!checkUp.GetComponent<BarrelCollideCheck> ().isCollide) {;
							player.transform.position = checkUp.transform.position;
							player.GetComponent<PlayerController> ().inBarrel = false;
							StartCoroutine(BarrelCldn());
						}
					}
					
					if (Input.GetKeyDown (KeyCode.S)) {
						if (!checkDown.GetComponent<BarrelCollideCheck> ().isCollide) {
							player.transform.position = checkDown.transform.position;
							player.GetComponent<PlayerController> ().inBarrel = false;
							StartCoroutine(BarrelCldn());
						}
					}
					if (Input.GetKeyDown (KeyCode.A)) {
						if (!checkLeft.GetComponent<BarrelCollideCheck> ().isCollide) {
							player.transform.position = checkLeft.transform.position;
							player.GetComponent<PlayerController> ().inBarrel = false;
							StartCoroutine(BarrelCldn());
						}
					}
					
					if (Input.GetKeyDown (KeyCode.D)) {
						if (!checkRight.GetComponent<BarrelCollideCheck> ().isCollide) {
							if (canUseBarrel) {
								player.transform.position = checkRight.transform.position;
								player.GetComponent<PlayerController> ().inBarrel = false;
								StartCoroutine(BarrelCldn());
							}
						}
					}
				}
			}
		}
	}
	
	void OnTriggerStay(Collider other)
	{
		if (other.CompareTag ("Player") && (!player.GetComponent<PlayerController> ().inBarrel)) 
		{
			player.GetComponent<PlayerController> ().hidden = false;
			popUpText.enabled = true;
		} else 
		{
			player.GetComponent<PlayerController> ().hidden = true;
			popUpText.enabled = false;
		}
	}

	void OnTriggerExit()
	{
		popUpText.enabled = false;
	}

	IEnumerator BarrelCldn()
	{	canUseBarrel = false;
		yield return new WaitForSeconds(cooldown);
		canUseBarrel = true;
	}

}
