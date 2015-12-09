using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BananaBarrel : MonoBehaviour {

	public PlayerController player;
	public GameObject guard;
	public GameObject guard1;
	public GameObject guard2;
	private Text popUpText;

	void Start()
	{
		popUpText = player.gameObject.GetComponent<PlayerController> ().interactText;
	}
	

	void OnTriggerStay(Collider other)
	{
		if (guard != null && guard1 != null && guard2 != null) {
			if(!player.bananananaMode){
				if (other.CompareTag ("Player")) {
					popUpText.enabled = true;
					if (Input.GetKey (KeyCode.E)) {
						if (player.bananaCount < 1) {
							player.bananaCount += 1;
						}
					}
				}
			}
		}
	}

	void OnTriggerExit()
	{
		popUpText.enabled = false;
	}
}
