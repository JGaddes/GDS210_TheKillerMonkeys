using UnityEngine;
using System.Collections;

public class StationaryGuard : MonoBehaviour {


	// Use this for initialization
	void Start () {
	
		gameObject.GetComponent<Guard>().GuardControl.SetBool("STOP", true);

	}
	
	// Update is called once per frame
	void Update () {
	

		gameObject.GetComponent<Guard>().GuardControl.SetBool("STOP", true);

	}
}
