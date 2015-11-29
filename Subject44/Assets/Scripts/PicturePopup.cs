using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PicturePopup : MonoBehaviour {

    public Image picture, pictureBack;
    public GameObject door;
    public Text interactText;

    // Use this for initialization
    void Start() {


        picture.enabled = false;
        pictureBack.enabled = false;
        interactText.enabled = false;

    }

    // Update is called once per frame
    void Update() {

    }

    void OnTriggerStay()
    {

        interactText.enabled = true;

        if (Input.GetKey(KeyCode.E))
        {
            interactText.enabled = false;
            picture.enabled = true;
            pictureBack.enabled = true;
            door.SetActive(false);
        }
    }

    void OnTriggerExit() {

        picture.enabled = false;
        pictureBack.enabled = false;
        interactText.enabled = false;
    }
}
