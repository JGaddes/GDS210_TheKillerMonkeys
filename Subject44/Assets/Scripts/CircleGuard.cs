using UnityEngine;
using System.Collections;

public class CircleGuard : MonoBehaviour {

    public GameObject spawnPoint;
	public GameObject player;
	public BoxCollider guardColl;
	public PlayerController playerController;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Vector3.Distance (transform.position, player.transform.position) < 1.5f) {
			if(player.GetComponent<PlayerController>().hidden == false)
            {
                player.transform.position = spawnPoint.transform.position;
            }
		}
	}
}
