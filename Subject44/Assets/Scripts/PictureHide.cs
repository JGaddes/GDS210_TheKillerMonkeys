using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PictureHide : MonoBehaviour {

	public Image picture;

	// Use this for initialization
	void Start () {


	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Return))
			picture.canvasRenderer.SetAlpha (0f);
	
	}
}
