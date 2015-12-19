using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelSplashAll : MonoBehaviour {
	
	public GameObject player;
	public Image dialoguePopUp, dialoguePopUpBack;
	public Image pressEnter;
	public Text enter;
	public bool timeUp = false;
	
	// Use this for initialization
	void Start () {
		
		pressEnter.enabled = false;
		enter.enabled = false;
		
		player.GetComponent<PlayerController>().canMove = false;
		
		StartCoroutine(ContinueTimer());
	}
	
	// Update is called once per frame
	void Update () {
		
		if(timeUp == true)
		{
			pressEnter.enabled = true;
			enter.enabled = true;
			
			if(Input.GetKeyDown(KeyCode.Return))
			{
				player.GetComponent<PlayerController>().canMove = true;

				Destroy(gameObject);
			}
		}
	}
	
	IEnumerator ContinueTimer()
	{
		yield return new WaitForSeconds(2f);
		timeUp = true;
	}
}
