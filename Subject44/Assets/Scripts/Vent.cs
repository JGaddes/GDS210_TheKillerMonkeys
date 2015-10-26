using UnityEngine;
using System.Collections;

public class Vent : MonoBehaviour {

	public Transform[] ventPoins;
	public GameObject player;

	public bool inVent = false;
	public float vCldn = 1f; //vent cooldown



	public void CallVent(){
		

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (inVent == false)
            {
                StartCoroutine(EnterVent());
            }

            if (inVent == true)
            {
                StartCoroutine(ExitVent());
            }
        }
    }


	public IEnumerator EnterVent()
	{
        player.transform.position = ventPoins[0].position;
		inVent = true;
		yield return new WaitForSeconds(vCldn);
	}

    public IEnumerator ExitVent()
    {
        player.transform.position = ventPoins[1].transform.position;
        inVent = false;
        yield return new WaitForSeconds(vCldn);
    }

}