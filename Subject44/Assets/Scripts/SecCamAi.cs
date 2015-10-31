using UnityEngine;
using System.Collections;

public class SecCamAi : MonoBehaviour
{

    public Transform waypoints;
    public bool loop = true, hitWall = false;
    public float waitTime = 0;
    public float rotationSpeed = 0.5f;

    private int currentWaypoint = 0;
    private CharacterController character;
    private Quaternion _lookRotation;
    private Vector3 _direction;

    void Start()
    {

        character = GetComponent<CharacterController>(); ;
    }

    void Update()
    {

        _direction = (waypoints.position - transform.position).normalized;
        _lookRotation = Quaternion.LookRotation(_direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * rotationSpeed);

        /*
        if (currentWaypoint < waypoints.Length)
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
        */

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

    IEnumerator patrol()
    {
        yield return new WaitForSeconds(waitTime);
    
    }
}
