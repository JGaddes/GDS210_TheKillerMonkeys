using UnityEngine;
using System.Collections;

public class PatrolAi : MonoBehaviour {
		
	public Transform[] waypoints;       
	public float patrolSpeed = 3f;       
	public bool  loop = true, hitWall = false;       
	public float dampingLook = 6.0f;          
	public float pauseDuration = 0;
    		
	private float curTime;
	private int currentWaypoint = 0;
	private CharacterController character;
		
	void  Start (){
			
		character = GetComponent<CharacterController>();
	}
		
	void  Update (){
			
		if(currentWaypoint < waypoints.Length){
			patrol();
		}else{    
			if(loop){
				currentWaypoint=0;
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
		
	void  patrol (){
			
		Vector3 target = waypoints[currentWaypoint].position;
		target.y = transform.position.y; 
		Vector3 moveDirection = target - transform.position;

		if(moveDirection.magnitude < 0.5f){
			if (curTime == 0)
				curTime = Time.time; 
			if ((Time.time - curTime) >= pauseDuration){
				currentWaypoint++;
				curTime = 0;
			}
		}else{

			var rotation = Quaternion.LookRotation(target - transform.position);
			transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * dampingLook);
			character.Move(moveDirection.normalized * patrolSpeed * Time.deltaTime);
		}  
	}
}
