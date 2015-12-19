using UnityEngine;
using System.Collections;

public class CheckPoint : MonoBehaviour {

	public PlayerController player;
	public GameObject lockDoor;

	void OnTriggerEnter(Collider col)
	{
		if(col.CompareTag("Player"))
		{
			Debug.Log ("Collided with player");
			player.GetComponent<PlayerController>().spawnPoint = gameObject.transform.position;
			lockDoor.SetActive(true);
		}
	}
}
