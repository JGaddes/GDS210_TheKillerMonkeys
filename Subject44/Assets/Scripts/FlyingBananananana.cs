using UnityEngine;
using System.Collections;

public class FlyingBananananana : MonoBehaviour {

	public Rigidbody rb;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		rb.AddForce (transform.forward * 10f);
	}
}
