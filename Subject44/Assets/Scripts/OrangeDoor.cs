using UnityEngine;
using System.Collections;

public class OrangeDoor : MonoBehaviour {
	
	public GameObject open, closed;
	public float speed = 2f;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		GameObject _player = GameObject.FindGameObjectWithTag("Player");
		
		if(_player.GetComponent<ChildCollider>().haveOraCard == true)
		{
			if (Vector3.Distance (transform.position, _player.transform.position) < 2f)
			{
				transform.position = Vector3.MoveTowards (transform.position, open.transform.position, speed * Time.deltaTime);
				
			}
			
			if (Vector3.Distance (transform.position, _player.transform.position) > 2f)
			{		
				transform.position = Vector3.MoveTowards (transform.position, closed.transform.position, speed * Time.deltaTime);
				
			}
		}
		
		if(_player.GetComponent<ChildCollider>().haveOraCard == false)
		{
			return;
		}
	}
}
