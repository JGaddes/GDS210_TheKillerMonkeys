using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PicturePopup : MonoBehaviour {

	public Image picture;

	// Use this for initialization
	void Start () {

		picture.canvasRenderer.SetAlpha (0f);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter ()
	{
		picture.canvasRenderer.SetAlpha (100f);
	}
}
