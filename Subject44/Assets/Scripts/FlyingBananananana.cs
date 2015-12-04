using UnityEngine;
using System.Collections;

public class FlyingBananananana : MonoBehaviour {

	public Rigidbody rb;
	private Vector3 direction;

	// Use this for initialization
	void Start () {

		GetDirection();

		transform.Rotate (direction);


	
	}
	
	// Update is called once per frame
	void Update () {
	
		transform.position += transform.forward * Time.deltaTime * 10f;
	}

	Vector3 GetDirection ()
	{
		direction = new Vector3 (Random.Range (-1f, 1f), 0, Random.Range (-1f, 1f));
		return direction;
	}

	void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.tag == "BananaBarrier")
		{
			GetDirection ();

			transform.Rotate (direction);
			rb.AddForce (transform.forward * 1f);
		}

		direction = -direction;
	}
}
