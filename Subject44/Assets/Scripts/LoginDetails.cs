using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class LoginDetails : MonoBehaviour {

    public Text loginDetails;

	// Use this for initialization
	void Start () {

        loginDetails.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other) {

        loginDetails.enabled = true;
    }
}
