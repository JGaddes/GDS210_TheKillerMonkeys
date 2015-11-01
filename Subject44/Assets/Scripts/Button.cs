using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

	public bool buttonOn = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(buttonOn)
		{
			gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load("GreenButton") as Sprite;
		}
	}

	public void OnTriggerEnter(Collider col)
	{
		if (col.tag == "player") 
			buttonOn = true;
		else
			buttonOn = false;
	}
}
