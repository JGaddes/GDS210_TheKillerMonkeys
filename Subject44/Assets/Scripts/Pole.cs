using UnityEngine;
using System.Collections;

public class Pole : MonoBehaviour {

	public GameObject player;
	
	// Update is called once per frame
	void Update () {
	
		if (Vector3.Distance (transform.position, player.transform.position) < 1.1f)
		{
			if(Input.GetKeyDown(KeyCode.Space))
			{
				if(player.GetComponent<PlayerController>().onPole == false)
				{
					player.transform.position = new Vector3 (transform.position.x, 1f, transform.position.z);
					player.GetComponent<PlayerController>().speed = 0f;
					player.GetComponent<PlayerController>().onPole = true;
                    player.GetComponent<PlayerController>().hidden = true;
                }
				
				else if(player.GetComponent<PlayerController>().onPole == true)
				{
					player.transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
					player.GetComponent<PlayerController>().speed = 5f;
					player.GetComponent<PlayerController>().onPole = false;
                    player.GetComponent<PlayerController>().hidden = false;
				}
			}
			
		}

	}
}
