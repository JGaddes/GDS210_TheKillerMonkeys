using UnityEngine;
using System.Collections;

public class PlayerRotate : MonoBehaviour
{
	public bool canRotate = true;

  

    // Update is called once per frame
    void Update()
    {
		if (canRotate) {
			if (Input.GetKey (KeyCode.W)) {
				transform.eulerAngles = new Vector3 (90, 0, 0);
			}

			if (Input.GetKey (KeyCode.A)) {
				transform.eulerAngles = new Vector3 (90, -90, 0);
			}

			if (Input.GetKey (KeyCode.S)) {
				transform.eulerAngles = new Vector3 (90, 180, 0);
			}

			if (Input.GetKey (KeyCode.D)) {
				transform.eulerAngles = new Vector3 (90, 90, 0);
			}

			// Diagonals
			if (Input.GetKey (KeyCode.W) && Input.GetKey (KeyCode.A)) {
			
				transform.eulerAngles = new Vector3 (90, -45, 0);
			}
		
			if (Input.GetKey (KeyCode.W) && Input.GetKey (KeyCode.D)) {
			
				transform.eulerAngles = new Vector3 (90, 45, 0);
			}
		
			if (Input.GetKey (KeyCode.S) && Input.GetKey (KeyCode.A)) {
			
				transform.eulerAngles = new Vector3 (90, 225, 0);
			}

			if (Input.GetKey (KeyCode.S) && Input.GetKey (KeyCode.D)) {
			
				transform.eulerAngles = new Vector3 (90, 135, 0);
			}
		}


    }
}