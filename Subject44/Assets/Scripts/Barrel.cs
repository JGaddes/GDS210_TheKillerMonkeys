using UnityEngine;
using System.Collections;

public class Barrel : MonoBehaviour {

    public GameObject player;
    public Vector3 origPos;

    void Update()
    {

        if (Vector3.Distance(transform.position, player.transform.position) < 2f)
        {

            if (player.GetComponent<PlayerController>().inBarrel == false)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    origPos = player.transform.position;
                    player.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                    player.GetComponent<PlayerController>().canMove = false;
                    player.GetComponent<PlayerController>().inBarrel = true;
                    player.GetComponent<PlayerController>().hidden = true;
                }
            }

            else if (player.GetComponent<PlayerController>().inBarrel == true)
            {
                if (Input.GetKeyDown(KeyCode.W))
                {
                    player.transform.position = new Vector3(transform.position.x, origPos.y, origPos.z + 1.5f);
                    player.GetComponent<PlayerController>().canMove = true;
                    player.GetComponent<PlayerController>().inBarrel = false;
                    player.GetComponent<PlayerController>().hidden = false;
                }

                if (Input.GetKeyDown(KeyCode.S))
                {
                    player.transform.position = new Vector3(transform.position.x, origPos.y, origPos.z - 1.5f);
                    player.GetComponent<PlayerController>().canMove = true;
                    player.GetComponent<PlayerController>().inBarrel = false;
                    player.GetComponent<PlayerController>().hidden = false;
                }

                if (Input.GetKeyDown(KeyCode.A))
                {
                    player.transform.position = new Vector3(origPos.x - 1.5f, origPos.y, transform.position.z);
                    player.GetComponent<PlayerController>().canMove = true;
                    player.GetComponent<PlayerController>().inBarrel = false;
                    player.GetComponent<PlayerController>().hidden = false;
                }

                if (Input.GetKeyDown(KeyCode.D))
                {
                    player.transform.position = new Vector3(origPos.x + 1.5f, origPos.y, transform.position.z);
                    player.GetComponent<PlayerController>().canMove = true;
                    player.GetComponent<PlayerController>().inBarrel = false;
                    player.GetComponent<PlayerController>().hidden = false;
                }
            }
        }
    }
}
