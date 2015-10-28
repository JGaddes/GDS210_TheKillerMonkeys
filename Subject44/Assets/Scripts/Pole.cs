using UnityEngine;
using System.Collections;

public class Pole : MonoBehaviour {

	public GameObject player;
    public Vector3 posOrigin;

	
	// Update is called once per frame
	void Update () {
	
		if (Vector3.Distance (transform.position, player.transform.position) < 1f)
		{
			if(Input.GetKeyDown(KeyCode.Space))
			{
				if(!player.GetComponent<PlayerController>().onPole)
				{
                    posOrigin = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
                    player.transform.position = new Vector3(transform.position.x, 5f, transform.position.z);
					Debug.Log ("up");
					player.GetComponent<PlayerController>().speed = 0f;
					Debug.Log ("stopped");
					player.GetComponent<PlayerController>().onPole = true;
					Debug.Log ("on");
					player.GetComponent<PlayerController>().hidden = true;
					Debug.Log ("hide");
				}
				
				else if(player.GetComponent<PlayerController>().onPole)
				{
                    player.transform.position = new Vector3(posOrigin.x, posOrigin.y, posOrigin.z);
					player.GetComponent<PlayerController>().speed = 15f;
					player.GetComponent<PlayerController>().onPole = false;
					player.GetComponent<PlayerController>().hidden = false;
				}
			}
			
		}

	}
}
