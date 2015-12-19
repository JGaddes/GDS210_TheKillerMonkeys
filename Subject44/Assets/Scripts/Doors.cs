using UnityEngine;
using System.Collections;

public class Doors : MonoBehaviour {

	public GameObject doorTop, openTop, closeTop, doorBot, openBot, closeBot;
	private float speed = 6.5f;
    public bool open;
	public AudioSource source;
	public AudioClip dooropening; 

    private Transform topPos, botPos;

    void Start()
    {
        topPos = doorTop.GetComponent<Transform>();
        botPos = doorBot.GetComponent<Transform>();
    }

    void Update()
    {
        if (!open)
        {
            doorTop.transform.position = Vector3.MoveTowards(topPos.position, closeTop.transform.position, speed * Time.deltaTime);
            doorBot.transform.position = Vector3.MoveTowards(botPos.position, closeBot.transform.position, speed * Time.deltaTime);
        }
    }


    void OnTriggerStay(Collider other)
    {   
        if (other.CompareTag("Player"))
        {
            doorTop.transform.position = Vector3.MoveTowards(topPos.position, openTop.transform.position, speed * Time.deltaTime);
            doorBot.transform.position = Vector3.MoveTowards(botPos.position, openBot.transform.position, speed * Time.deltaTime);
            open = true;
        }

		if (other.CompareTag("Guard"))
		{
			doorTop.transform.position = Vector3.MoveTowards(topPos.position, openTop.transform.position, speed * Time.deltaTime);
			doorBot.transform.position = Vector3.MoveTowards(botPos.position, openBot.transform.position, speed * Time.deltaTime);
			open = true;
		}
    }


    void OnTriggerExit (Collider other)
    {
        if (other.CompareTag("Player"))
        {
            open = false; 
        }

		if (other.CompareTag("Guard"))
		{
			open = false; 
		}
    }

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			open = true;
			source.PlayOneShot(dooropening); 
		}
		
		if (other.CompareTag("Guard"))
		{
			open = true;
			source.PlayOneShot(dooropening);
		}
	}

}
