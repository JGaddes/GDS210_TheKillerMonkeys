using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MonkeyKin : MonoBehaviour {

	public bool lockpicking;
	public AudioClip badMonkey, goodMonkey;
	public Button yes, no;


	// Use this for initialization
	void Start () {
	
		yes.enabled = false;
		no.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
		if(lockpicking)
		{
			if (Vector3.Distance (transform.position, GameObject.FindGameObjectWithTag("MonkeyKin").transform.position) < 2f)
			{
				if(Input.GetKeyDown(KeyCode.Space))
				{
					yes.enabled = true;
					no.enabled = true;
				}
			}
		}


	}

	public void saveMonkey()
	{
		//goodMonkey.Play ();
		GameObject.FindGameObjectWithTag ("MonkeyKin").SetActive (false);
	}

	public void leaveMonkey()
	{
		//badMonkey.Play ();
	}
}
