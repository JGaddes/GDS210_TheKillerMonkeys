using UnityEngine;
using System.Collections;

public class HasKey : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Player"))
		{
			GameObject.FindGameObjectWithTag("Monkey Kin").GetComponent<MonkeyKin>().key = true;
		}
	}
}
