using UnityEngine;
using System.Collections;

public class BarrelCollideCheck : MonoBehaviour {

	public bool isCollide = false;

	void OnCollisionStay(Collision other)
	{
		if (other.gameObject.tag == "Wall") 
		{
			isCollide = true;
		}
	}
}
