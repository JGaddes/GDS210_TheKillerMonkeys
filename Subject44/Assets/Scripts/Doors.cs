using UnityEngine;
using System.Collections;

public class Doors : MonoBehaviour {

	public GameObject open, closed;
	public float speed = 2f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		GameObject _player = GameObject.FindGameObjectWithTag("Player");

		if (Vector3.Distance (transform.position, _player.transform.position) < 2f)
		{
			transform.position = Vector3.MoveTowards (transform.position, open.transform.position, speed * Time.deltaTime);

		}

		if (Vector3.Distance (transform.position, _player.transform.position) > 2f)
		{		
			transform.position = Vector3.MoveTowards (transform.position, closed.transform.position, speed * Time.deltaTime);

		}


		/*GameObject _enemy = GameObject.Find ("Door360Guard");

		if (Vector3.Distance (transform.position, _enemy.transform.position) < 2f)
		{
			transform.position = Vector3.MoveTowards (transform.position, open.transform.position, speed * Time.deltaTime);
			
		}
		
		if (Vector3.Distance (transform.position, _enemy.transform.position) > 2f)
		{		
			transform.position = Vector3.MoveTowards (transform.position, closed.transform.position, speed * Time.deltaTime);
			
		}*/
	}

}
