using UnityEngine;
using System.Collections;

public class PatrolAi : MonoBehaviour {
		
	public Transform[] waypoint;
    public Vector3 target;      
	public float patrolSpeed = 3f;       
	public bool  loop = true, hitWall = false, stopped = false;       
	public float dampingLook = 6.0f;          
	public float pauseDuration = 0;
		
	private float curTime;
	private int currentWaypoint = 0;
	private CharacterController character;

	//public Animator GuardAnimator;
		
	void  Start ()
	{
		character = GetComponent<CharacterController>();
	}
		
	void  Update (){
			
		if(currentWaypoint < waypoint.Length){
			patrol();
		}
		else
		{    
			if(loop)
			{
				currentWaypoint=0;
			} 
		}

		if(gameObject.name == "Guard")
		{
			if (stopped == true)
			{
				gameObject.GetComponent<Guard>().GuardControl.SetBool("STOP", true);
				//GuardAnimator.StartPlayback();
			}
			
			if (stopped == false)
			{
				gameObject.GetComponent<Guard>().GuardControl.SetBool("STOP", false);
				//GuardAnimator.StopPlayback();
			}
		}


	}
		
	void  patrol ()
    {	
		target = waypoint[currentWaypoint].position;
		target.y = transform.position.y; 
		Vector3 moveDirection = target - transform.position;

		if(moveDirection.magnitude < 0.5f){
			if (curTime == 0)
				curTime = Time.time; 
				stopped = true;
			if ((Time.time - curTime) >= pauseDuration){
				currentWaypoint++;
				curTime = 0;
			}
		}
		else{

			var rotation = Quaternion.LookRotation(target - transform.position);
			transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * dampingLook);
			character.Move(moveDirection.normalized * patrolSpeed * Time.deltaTime);
			stopped = false;
		}  
	}
}
