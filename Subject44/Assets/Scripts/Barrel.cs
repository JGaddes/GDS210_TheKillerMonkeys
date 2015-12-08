using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Barrel : MonoBehaviour {

	public GameObject checkUp;
	public GameObject checkDown;
	public GameObject checkLeft;
	public GameObject checkRight;
    public GameObject player;
    public Vector3 origPos;
	public Text popUpText;

	private float cooldown = 0.25f;
	private bool canUseBarrel = true;


	void Start()
	{
		popUpText.enabled = false;
	}

    void Update()
    {
		if (Vector3.Distance (transform.position, player.transform.position) >= 2f) {
			if (player.GetComponent<PlayerController> ().inBarrel == false) {
				popUpText.enabled = false;
			}
		}

        if (Vector3.Distance(transform.position, player.transform.position) < 2f)
        {
            if (player.GetComponent<PlayerController>().inBarrel == false)
            {
				popUpText.enabled = true;
				if (Input.GetKeyDown(KeyCode.E))
				{
					if(canUseBarrel)
					{
						StartCoroutine(BarrelCooldown());
						origPos = player.transform.position;
						player.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
						player.GetComponent<PlayerController>().canMove = false;
						player.GetComponent<PlayerController>().inBarrel = true;
						player.GetComponent<PlayerController>().hidden = true;
					}
				}
			}
			
			else if (player.GetComponent<PlayerController>().inBarrel)
			{
				popUpText.enabled = false;
				if (Input.GetKeyDown(KeyCode.W))
				{
					if(!checkUp.GetComponent<BarrelCollideCheck>().isCollide)
					{
						if(canUseBarrel)
						{
							StartCoroutine(BarrelCooldown());
							player.transform.position = checkUp.transform.position;
							player.GetComponent<PlayerController>().canMove = true;
							player.GetComponent<PlayerController>().inBarrel = false;
							player.GetComponent<PlayerController>().hidden = false;
						}
					}
				}
				if (Input.GetKeyDown(KeyCode.S))
				{
					if(!checkDown.GetComponent<BarrelCollideCheck>().isCollide)
					{
						if(canUseBarrel)
						{
							StartCoroutine(BarrelCooldown());
							player.transform.position = checkDown.transform.position;
							player.GetComponent<PlayerController>().canMove = true;
							player.GetComponent<PlayerController>().inBarrel = false;
							player.GetComponent<PlayerController>().hidden = false;
						}
					}
				}
				if (Input.GetKeyDown(KeyCode.A))
				{
					if(!checkLeft.GetComponent<BarrelCollideCheck>().isCollide)
					{
						if(canUseBarrel)
						{
							StartCoroutine(BarrelCooldown());
							player.transform.position = checkLeft.transform.position;
							player.GetComponent<PlayerController>().canMove = true;
							player.GetComponent<PlayerController>().inBarrel = false;
							player.GetComponent<PlayerController>().hidden = false;
						}
					}
				}
				if (Input.GetKeyDown(KeyCode.D))
				{
					if(!checkRight.GetComponent<BarrelCollideCheck>().isCollide)
					{
						if(canUseBarrel)
						{
							StartCoroutine(BarrelCooldown());
							player.transform.position = checkRight.transform.position;
							player.GetComponent<PlayerController>().canMove = true;
							player.GetComponent<PlayerController>().inBarrel = false;
							player.GetComponent<PlayerController>().hidden = false;
						}
					}
				}
        	}
    	}
	}

	IEnumerator BarrelCooldown()
	{
		canUseBarrel = false;
		yield return new WaitForSeconds (cooldown);
		canUseBarrel = true;
	}
}
