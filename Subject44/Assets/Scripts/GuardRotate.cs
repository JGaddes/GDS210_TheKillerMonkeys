using UnityEngine;
using System.Collections;

public class GuardRotate : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
		StartCoroutine (GuardCoroutine ());
	}
	
	// Update is called once per frame
	void Update () {

	
	}

	IEnumerator GuardCoroutine()
	{
		transform.eulerAngles = new Vector3(0, 90, 0);
		yield return new WaitForSeconds (3);
		transform.eulerAngles = new Vector3(0, -90, 0);
		yield return new WaitForSeconds (3);
	}
}
