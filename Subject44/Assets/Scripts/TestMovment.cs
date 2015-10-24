using UnityEngine;
using System.Collections;

public class TestMovment : MonoBehaviour {

	public CharacterController controller;
	public float speed = 15f;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		float _vert = -Input.GetAxis("Vertical");
		float _hori = -Input.GetAxis ("Horizontal");
		
		Vector3 _moveDirection = transform.TransformDirection (_hori, 0, _vert).normalized; 
		controller.SimpleMove(((_moveDirection * speed) * Time.deltaTime) * speed);
		_moveDirection = Vector3.zero;
	}
}
