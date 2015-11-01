using UnityEngine;
using System.Collections;

public class BlueDoor : MonoBehaviour {

	public GameObject open, closed;
	public float speed = 2f;
	public GameObject _player;

	// Use this for initialization
	void Start () {

		_player = GameObject.FindGameObjectWithTag("Player");
	
	}
	
	// Update is called once per frame
	void Update () {
	

		
		if (_player.GetComponent<ChildCollider>().haveBluCard) {
			if (Vector3.Distance (transform.position, _player.transform.position) < 2f) {
				transform.position = Vector3.MoveTowards (transform.position, open.transform.position, speed * Time.deltaTime);
				
			}
			else if (Vector3.Distance (transform.position, _player.transform.position) > 2f) {		
				transform.position = Vector3.MoveTowards (transform.position, closed.transform.position, speed * Time.deltaTime);
				
			}
		} else
			return;
	}
}
