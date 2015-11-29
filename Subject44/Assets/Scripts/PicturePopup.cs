using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PicturePopup : MonoBehaviour {

	public Image picture, pictureBack;

	// Use this for initialization
	void Start () {

		picture.canvasRenderer.SetAlpha (0f);
		pictureBack.canvasRenderer.SetAlpha (0f);

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay ()
	{
		if(Input.GetKeyDown(KeyCode.E))
		{
			picture.canvasRenderer.SetAlpha (100f);
			pictureBack.canvasRenderer.SetAlpha (100f);
		}
	}
}
