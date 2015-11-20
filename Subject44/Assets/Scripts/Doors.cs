using UnityEngine;
using System.Collections;

public class Doors : MonoBehaviour {

	public GameObject doorTop, openTop, closeTop, doorBot, openBot, closeBot;
	public float speed = 10f;
    public bool open;

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
    }


    void OnTriggerExit (Collider other)
    {
        if (other.CompareTag("Player"))
        {
            open = false; 
        }
    }
}
