using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ChildCollider : MonoBehaviour {

    public PlayerController player;
    public GuiScript guiScript;

    public GameObject purKeyCard;
    public GameObject bluKeyCard;
    public GameObject greKeyCard;
    public GameObject oraKeyCard;
    public GameObject pinKeyCard;
    public GameObject idCard;

	public GameObject[] purDoors;
	public GameObject[] bluDoors;
	public GameObject[] greDoors;
	public GameObject[] oraDoors;
	public GameObject[] pinDoors;

    public List<PatrolAi> patrol = new List<PatrolAi>();
    public List<GameObject> guards = new List<GameObject>();
	
	public bool haveBluCard = false, haveOraCard = false, haveGreCard = false, havePurCard = false, havePinCard = false, haveIdCard = false;

	public Sprite green, red;
	public AudioSource source; 
	public AudioClip pickupAnything; 


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
    }
	
	
	public void OnTriggerEnter(Collider col)
    {
        
		// Power ups
		if (col.CompareTag ("Banana")) {
			player.bananaCount += 1;
			player.banana.enabled = true;
			player.banana.canvasRenderer.SetAlpha (1f);
			Destroy (col.gameObject);
			source.PlayOneShot(pickupAnything);
			source.volume = 0.6f;
		}

		if (col.CompareTag ("Pill")) {
			player.pillCount += 1;
			Destroy (col.gameObject);
			source.PlayOneShot(pickupAnything);
			source.volume = 0.6f;
		}
		

		// Interactables

		if (col.CompareTag ("Button")) {
			col.gameObject.GetComponent<SpriteRenderer> ().sprite = green;
			col.gameObject.GetComponent<Button> ().buttonOn = true;
		}



		// Pick up Keys
		if (col.CompareTag ("Blue Key")) {
			haveBluCard = true;
			Destroy (col.gameObject);
			source.PlayOneShot(pickupAnything);
			source.volume = 0.6f;
			bluKeyCard.SetActive (true);

			foreach(GameObject d in bluDoors)
			{
				d.GetComponent<Collider> ().enabled = true;
			}
		}

		if (col.CompareTag ("Orange Key")) {
			haveOraCard = true;
			oraKeyCard.SetActive (true);
			Destroy (col.gameObject);
			source.PlayOneShot(pickupAnything);
			source.volume = 0.6f;
            oraKeyCard.SetActive(true);

            foreach (GameObject d in oraDoors)
            {
                d.GetComponent<Collider>().enabled = true;
            }
        }

		if (col.CompareTag ("Pink Key")) {
			havePinCard = true;
			pinKeyCard.SetActive (true);
			Destroy (col.gameObject);
			source.PlayOneShot(pickupAnything);
			source.volume = 0.6f;
            pinKeyCard.SetActive(true);

            foreach (GameObject d in pinDoors)
            {
                d.GetComponent<Collider>().enabled = true;
            }
        }

		if (col.CompareTag ("Purple Key")) {
			havePurCard = true;
			purKeyCard.SetActive (true);
			Destroy (col.gameObject);
			source.PlayOneShot(pickupAnything);
			source.volume = 0.6f;
		}

		if (col.CompareTag ("Green Key")) {
			haveGreCard = true;
			greKeyCard.SetActive (true);
			Destroy (col.gameObject);
			source.PlayOneShot(pickupAnything);
			source.volume = 0.6f;

            greKeyCard.SetActive(true);

            foreach (GameObject d in greDoors)
            {
                d.GetComponent<Collider>().enabled = true;
            }
        }

        if (col.CompareTag ("IDCard")) {

            haveIdCard = true;
            idCard.GetComponent<Image>().enabled = true;
            idCard.SetActive(true);
            Destroy(col.gameObject);
			source.PlayOneShot(pickupAnything);
			source.volume = 0.6f;
        }
	} 

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Shadow"))
        {
            player.hidden = false;
        }

		if(other.CompareTag("Button"))
		{
			other.gameObject.GetComponent<SpriteRenderer>().sprite = red;
		}
    }
}
