using UnityEngine;
using System.Collections;

public class SecCamAi : MonoBehaviour
{

    public Transform[] waypoint;
    public bool loop = true, hitWall = false;
    public bool isLooking = false;
    public bool activated = true;
    public float dampingLook;
    public float pauseDuration;
    public float waitTime;

    private float curTime;
    private int currentWaypoint = 0;
    private CharacterController character;


    void Update()
    {
        if (activated)
        {
            Debug.Log("Still active");
            if (currentWaypoint < waypoint.Length)
            {
                patrol();
            }
            else
            {
                if (loop)
                {
                    currentWaypoint = 0;
                }
            }

            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, 2.5f))
            {
                if (hit.collider.tag == "Wall")
                {
                    hitWall = true;
                }
                else if (hit.collider.tag != "Wall")
                {
                    hitWall = false;
                }
            }

        }
    }

    void patrol()
    {

        Vector3 target = waypoint[currentWaypoint].position;
        target.y = transform.position.y;

        if (isLooking)
        {
            if (curTime == 0)
            {
                curTime = Time.time;
            }

            if ((Time.time - curTime) >= pauseDuration)
            {
                currentWaypoint++;
                curTime = 0;
                isLooking = false;
            }
        }

        else
        {

            var rotation = Quaternion.LookRotation(target - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * dampingLook);
            StartCoroutine(Wait());
            
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(waitTime);
        isLooking = true;
    }
}
