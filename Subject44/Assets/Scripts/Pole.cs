using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Pole : MonoBehaviour {

	public GameObject player;
	public Text popUpText;


	void Start()
	{
		popUpText.enabled = false;
	}

	void Update () {

		if (Vector3.Distance (transform.position, player.transform.position) >= 1.5f) {
			if (player.GetComponent<PlayerController> ().onPole == false) {
				popUpText.enabled = false;
			}
		}
	
		if (Vector3.Distance (transform.position, player.transform.position) < 1.5f)
		{
			popUpText.enabled = true;
			if(Input.GetKeyDown(KeyCode.Space))
			{
				if(player.GetComponent<PlayerController>().onPole == false)
				{
					player.transform.position = new Vector3(transform.position.x, 1f, transform.position.z);
                    player.GetComponent<PlayerController>().canMove = false;
					player.GetComponent<PlayerController>().onPole = true;
                    player.GetComponent<PlayerController>().hidden = true;
				}
				
				else if(player.GetComponent<PlayerController>().onPole == true)
				{
					player.transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
                    player.GetComponent<PlayerController>().canMove = true;
					player.GetComponent<PlayerController>().onPole = false;
                    player.GetComponent<PlayerController>().hidden = false;
                }
			}
			
		}

	}
}
