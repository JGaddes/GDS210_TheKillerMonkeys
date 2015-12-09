using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Pole : MonoBehaviour {

	public GameObject player;
	public Text popUpText;

	private Vector3 origPos;

	void Start()
	{
		popUpText = player.gameObject.GetComponent<PlayerController> ().interactText;
	}

	void Update()
	{
		if (Vector3.Distance (player.transform.position, transform.position) < 1.5f) {
			if (Input.GetKeyDown (KeyCode.E)) {
				if (player.GetComponent<PlayerController> ().onPole == false) {
					origPos = player.transform.position;
					player.transform.position = new Vector3 (transform.position.x, transform.position.y + 1f, transform.position.z);
					player.GetComponent<PlayerController> ().canMove = false;
					player.GetComponent<PlayerController> ().onPole = true;
					player.GetComponent<PlayerController> ().hidden = true;
				} else if (player.GetComponent<PlayerController> ().onPole == true) {
					popUpText.enabled = false;
					player.transform.position = origPos;
					player.GetComponent<PlayerController> ().canMove = true;
					player.GetComponent<PlayerController> ().onPole = false;
					player.GetComponent<PlayerController> ().hidden = false;
				}
			}
		}
	}

	void OnTriggerStay(Collider other)
	{
		if (other.CompareTag ("Player") && !player.GetComponent<PlayerController> ().onPole) {
			popUpText.enabled = true;
		} else {
			popUpText.enabled = false;
		}
	}

	void OnTriggerExit()
	{
		popUpText.enabled = false;
	}
}
