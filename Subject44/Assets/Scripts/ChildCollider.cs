using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ChildCollider : MonoBehaviour {

	public PlayerController player;
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
                    if (!player.hidden)
                    {
                        player.speed = 0f;
                        transform.position = player.spawnPoint.transform.position;
                        player.useBanana = false;
                        player.bananaSlider.value = 0;
                        player.speed = 5f;
                    }
                }
            }
        }
		
		if (other.CompareTag ("Shadow")) {
			player.hidden = true;	
		}
	}
	
	
	void OnTriggerEnter(Collider col){
		if (col.CompareTag("Banana")){
			Destroy(col.gameObject);
		}
	}
	
	void OnTriggerExit(Collider other){
		if (other.CompareTag ("Shadow")) {
			player.hidden = false;
        }
	}

}
