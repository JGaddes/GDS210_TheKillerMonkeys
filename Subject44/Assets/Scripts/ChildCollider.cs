using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ChildCollider : MonoBehaviour {

    public PlayerController player;
    public GameObject spawnPoint;
    public TextShow tutorial;
	public AudioSource source; 
	public AudioClip detected;

    public List<PatrolAi> patrol = new List<PatrolAi>();
    public List<GameObject> guards = new List<GameObject>();


    // Use this for initialization
    void Start () {
		
        player = gameObject.GetComponentInParent<PlayerController>();
        source = gameObject.GetComponentInParent<AudioSource>();
        detected = gameObject.GetComponentInParent<PlayerController>().detected;

        foreach (GameObject g in GameObject.FindGameObjectsWithTag("Guard"))
        {
            guards.Add(g);
        }

        foreach (GameObject g in GameObject.FindGameObjectsWithTag("Guard"))
        {
            patrol.Add(g.GetComponent<PatrolAi>());
        }
	}

    public void Update()
    {
        Debug.Log("You have " + player.keyCardCount + " keycards");
    }

	void OnTriggerStay (Collider other)
	{

        if (other.CompareTag("Detect"))
        {
            for (int i = 0; i < patrol.Count; i++)
            {
                if (patrol[i].hitWall)
                    return;
                else
                {
                    if (!player.hidden && !patrol[i].hitWall)
                    {
                        player.canMove = false;
                        transform.position = spawnPoint.transform.position;
                        player.useBanana = false;
                        player.bananaSlider.value = 0;
                        player.canMove = true;
						source.Play();
                    }
                }
            }
        }
		
		if (other.CompareTag ("Shadow")) {
			player.hidden = true;	
		}

        if (other.CompareTag("Door"))
        {
            if (player.keyCardCount > 0)
            {
                player.keyCardCount -= 1;
                Destroy(other.gameObject);
            }
        }
	}
	
	
	void OnTriggerEnter(Collider col){
		if (col.CompareTag("Banana")){
			Destroy(col.gameObject);
		}

        if (col.CompareTag("Key Card"))
        {
            player.keyCardCount += 1;
            Destroy(col.gameObject);
        }

        if(col.CompareTag("Tutorial"))
        {
            tutorial.CallText();
        }
	}
	
	void OnTriggerExit(Collider other){
		if (other.CompareTag ("Shadow")) {
			player.hidden = false;
        }
	}

}
