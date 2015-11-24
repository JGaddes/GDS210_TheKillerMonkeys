using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ChildCollider : MonoBehaviour {

    public PlayerController player;
	//public DetectPlayer detected;
    public GameObject spawnPoint;
    public GuiScript guiScript;

    public GameObject purKeyCard;
    public GameObject bluKeyCard;
    public GameObject greKeyCard;
    public GameObject oraKeyCard;
    public GameObject pinKeyCard;

    public List<PatrolAi> patrol = new List<PatrolAi>();
    public List<GameObject> guards = new List<GameObject>();


    public bool haveBluCard = false;
	public bool haveOraCard = false;
	public bool haveGreCard = false;
	public bool havePurCard = false;
	public bool havePinCard = false;

	public Sprite green, red;


    // Use this for initialization
    void Start () {

        player = gameObject.GetComponentInParent<PlayerController>();

        foreach (GameObject g in GameObject.FindGameObjectsWithTag("Guard"))
        {
            guards.Add(g);
        }

        foreach (GameObject g in GameObject.FindGameObjectsWithTag("Guard"))
        {
            patrol.Add(g.GetComponent<PatrolAi>());
        }
	}

	void OnTriggerStay (Collider other)
	{
		if (other.CompareTag ("Shadow")) {
            if (!player.useBanana)
            {
                player.hidden = true;
            }
		}

        // Doors
        if (other.CompareTag("Door"))
        {
            other.gameObject.GetComponent<MeshRenderer>().enabled = false;
        }

        if(other.CompareTag("Blue Door"))
        {
            if(haveBluCard)
            {
                other.gameObject.SetActive(false);
            }
        }

        if (other.CompareTag("Orange Door"))
        {
            if (haveOraCard)
            {
                other.gameObject.SetActive(false);
            }
        }

        if (other.CompareTag("Green Door"))
        {
            if (haveGreCard)
            {
                other.gameObject.SetActive(false);
            }
        }

        if (other.CompareTag("Purple Door"))
        {
            if (havePurCard)
            {
                other.gameObject.SetActive(false);
            }
        }

        if (other.CompareTag("Pink Door"))
        {
            if (havePinCard)
            {
                other.gameObject.SetActive(false);
            }
        }
    }
	
	
	public void OnTriggerEnter(Collider col)
    {
        
		// Power ups
		if (col.CompareTag ("Banana")) {
			player.bananaCount += 1;
			player.banana.enabled = true;
			player.banana.canvasRenderer.SetAlpha (1f);
			Destroy (col.gameObject);
		}

		if (col.CompareTag ("Pill")) {
			player.pillCount += 1;
			Destroy (col.gameObject);
		}

		/*if (col.CompareTag("Collectible"))
		{
			player.collect1.enabled = true;
			Destroy(col.gameObject);
		}*/

		// Interactables

		if (col.CompareTag ("Computer")) {
			if (player.havePill) {
				guiScript.ComputerActive ();
				player.pillCount -= 1;
			}
		}


		if (col.CompareTag ("Button")) {
			col.gameObject.GetComponent<SpriteRenderer> ().sprite = green;
			col.gameObject.GetComponent<Button> ().buttonOn = true;
		}

		// Pick up Keys
		if (col.CompareTag ("Blue Key")) {
			haveBluCard = true;
			Destroy (col.gameObject);
			bluKeyCard.SetActive (true);
		}

		if (col.CompareTag ("Orange Key")) {
			haveOraCard = true;
			oraKeyCard.SetActive (true);
			Destroy (col.gameObject);
		}

		if (col.CompareTag ("Pink Key")) {
			havePinCard = true;
			pinKeyCard.SetActive (true);
			Destroy (col.gameObject);
		}

		if (col.CompareTag ("Purple Key")) {
			havePurCard = true;
			purKeyCard.SetActive (true);
			Destroy (col.gameObject);
		}

		if (col.CompareTag ("Green Key")) {
			haveGreCard = true;
			greKeyCard.SetActive (true);
			Destroy (col.gameObject);
		}

	} 

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Shadow"))
        {
            player.hidden = false;
        }

        // Doors
        if (other.CompareTag("Door"))
        {
            other.gameObject.GetComponent<MeshRenderer>().enabled = true;
        }

        // Interactables
        if (other.gameObject.tag == "Computer")
        {
            guiScript.ComputerUnActive();
        }

		if(other.CompareTag("Button"))
		{
			other.gameObject.GetComponent<SpriteRenderer>().sprite = red;
		}
    }
}
