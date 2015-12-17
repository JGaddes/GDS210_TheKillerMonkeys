using UnityEngine;
using System.Collections;

public class Elevator : MonoBehaviour {

    public float cooldown = 10f;

	// Use this for initialization
	void Start () {
        StartCoroutine(MyCoroutine());
    }
	
	// Update is called once per frame
	void Update () {
	    
	}

    IEnumerator MyCoroutine()
    {

        yield return new WaitForSeconds(cooldown);
        Application.LoadLevel("Level1.3");
    }
}
