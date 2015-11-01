using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

	public bool buttonOn;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(buttonOn)
		{
			gameObject.SetActive(false);
		}
	}

	public void OnTriggerEnter(Collider col)
	{
		if(col.CompareTag("player"))
		{
			buttonOn = true;
		}
	}
}
