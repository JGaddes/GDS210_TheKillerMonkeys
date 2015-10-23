using UnityEngine;
using System.Collections;

public class Vent : MonoBehaviour {

	public Transform[] ventPoins;
	public GameObject player;

	public bool inVent = false;
	public float vCldn = 1f; //vent cooldown



	public void CallVent(){
		StartCoroutine (UseVent ());
	}


	public IEnumerator UseVent()
	{
		if (inVent = false){
			player.transform.position = ventPoins[0].position;
			inVent = true;
			yield return new WaitForSeconds(vCldn);

		}

		if (inVent = true){
			player.transform.position = ventPoins[1].transform.position;
			inVent = false;
			yield return new WaitForSeconds (vCldn);
		}
	}

}