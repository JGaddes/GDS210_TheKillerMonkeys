using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class  PictureScript : MonoBehaviour {

    public Image picture, pictureBack;
	
    public GameObject door;
	public GameObject player;

	private Text popUpText;




    // Use this for initialization
    void Start() 
	{
		popUpText = player.gameObject.GetComponent<PlayerController> ().interactText;
        picture.enabled = false;
        pictureBack.enabled = false;
    }


	void Update()
	{
		if (Vector3.Distance (transform.position, player.transform.position) < 1.0f) 
		{
			popUpText.enabled = true;
			if (Input.GetKeyDown (KeyCode.E))
			{	
				if(!picture.enabled)
				{
					picture.enabled = true;
					pictureBack.enabled = true;
					player.GetComponent<PlayerController>().canMove = false;
					popUpText.enabled = false;
				}
			}
			if (picture.enabled)
			{
				if (Input.GetKeyDown (KeyCode.Return)) 
				{
					popUpText.enabled = false;
					door.SetActive(false);
					player.GetComponent<PlayerController>().canMove = true;
					picture.enabled = false;
					pictureBack.enabled = false;
					gameObject.SetActive(false);
				}
			}
		}
	}
}
