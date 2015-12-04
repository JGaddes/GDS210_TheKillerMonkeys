using UnityEngine;
using System.Collections;

public class BananaRotate : MonoBehaviour {

	public Rigidbody bananaRb;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		//transform.Rotate (0, 20, 0);
		bananaRb.AddForce(transform.right * 50f);
	}
}
