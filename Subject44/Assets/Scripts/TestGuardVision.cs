using UnityEngine;
using System;
using System.Collections;

public class TestGuardVision : MonoBehaviour {

	public float fieldOfViewAngle = 110f;
	public bool playerInSight;

	private GameObject player;
	private SphereCollider col;



	void Awake(){
		col = GetComponent<SphereCollider> ();
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	void OnTriggerStay(Collider other)
	{

		if (other.gameObject == player) {
			playerInSight = false;

			Vector3 direction = other.transform.position - transform.position;
			float angle = Vector3.Angle(direction, transform.forward);

			if(angle < fieldOfViewAngle * 0.5f)
			{
				RaycastHit hit;

				if(Physics.Raycast(transform.position + transform.up, direction.normalized, out hit, col.radius))
				{
					if(hit.collider.gameObject == player)
					{
						playerInSight = true;
						Debug.Log("I see you");
					}
				}
			}
		}
	}
}
