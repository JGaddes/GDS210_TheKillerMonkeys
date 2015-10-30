using UnityEngine;
using System.Collections;

public class Pole : MonoBehaviour {

	public GameObject player;
    public Vector3 origPos;

	
	// Update is called once per frame
	void Update () {
	
		if (Vector3.Distance (transform.position, player.transform.position) < 1f)
		{
			if(Input.GetKeyDown(KeyCode.Space))
			{
				if(!player.GetComponent<PlayerController>().onPole)
				{
                    origPos = player.transform.position;
                    player.transform.position = new Vector3(transform.position.x, 5f, transform.position.z);
					player.GetComponent<PlayerController>().speed = 0f;
					player.GetComponent<PlayerController>().onPole = true;
					player.GetComponent<PlayerController>().hidden = true;
				}
				
				else if(player.GetComponent<PlayerController>().onPole)
				{
                    Debug.Log("You Climbed down");
                    player.transform.position = origPos;
					player.GetComponent<PlayerController>().speed = 5f;
					player.GetComponent<PlayerController>().onPole = false;
					player.GetComponent<PlayerController>().hidden = false;
				}
			}
			
		}

	}
}
