using UnityEngine;
using System.Collections;

public class Doors : MonoBehaviour {

	public GameObject doorUp, openUp, closedUp, doorDown, openDown, closedDown;
	public float speed = 2f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//Door opens
	void OnTriggerStay (Collider other)
	{
		if(other.CompareTag("Player"))
		{
			doorUp.transform.position = Vector3.MoveTowards (transform.position, openUp.transform.position, speed * Time.deltaTime);
			doorDown.transform.position = Vector3.MoveTowards (transform.position, openDown.transform.position, speed * Time.deltaTime);
		}
	}

	//Door closes
	void OnTriggerLeave (Collider other)
	{
		if(other.CompareTag("Player"))
		{
			doorUp.transform.position = Vector3.MoveTowards (transform.position, closedUp.transform.position, speed * Time.deltaTime);
			doorDown.transform.position = Vector3.MoveTowards (transform.position, closedDown.transform.position, speed * Time.deltaTime);
		}
	}

}
