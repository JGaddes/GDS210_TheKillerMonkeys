using UnityEngine;
using System.Collections;

public class RedDoor : MonoBehaviour {

	public GameObject button;

	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {

		if (button.GetComponentInChildren<Button> ().buttonOn)
		{
			gameObject.SetActive(false);
		}
	
	}
}
