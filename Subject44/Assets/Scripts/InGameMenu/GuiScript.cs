using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class GuiScript : MonoBehaviour {
	
	public Slider bananaMode;
	public PlayerController playerController;
	public List<GameObject> bananaList;

	public Slider bananaSlider;

	public int count;
	public float cooldown = 2;
	
	// Use this for initialization
	void Start () {
	
		playerController.GetComponent <PlayerController>();
		bananaSlider.value = 0;
	}
	
	// Update is called once per frame
	void Update () {

		bananaSlider.value -=  Time.deltaTime * cooldown; 

		if (Input.GetKeyDown (KeyCode.B) && bananaSlider.value == 0) {
			
			if (count < 3)
			{
				bananaList[count].gameObject.GetComponent<Image> ().enabled = false;
				count++;
				playerController.BananaMode();
				bananaSlider.value = 100;
			}
	}
}
}