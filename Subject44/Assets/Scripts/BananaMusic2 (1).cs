using UnityEngine;
using System.Collections;

public class BananaMusic2 : MonoBehaviour {
	
	public float maxPitch = 1.5f;

	public AudioReverbPreset reverbPreset;
	public AudioLowPassFilter lowpassFilter; 
	public PlayerController player; 
	AudioSource audio;
	
	void Start() 
	{
		audio = GetComponent<AudioSource>();
	}

	
	void Update() 
	{
		if (player.useBanana) 
		{
			if (GetComponent<AudioSource> ().pitch < maxPitch) 
			{
				GetComponent<AudioSource> ().pitch += Time.deltaTime; 
				GetComponent<AudioReverbFilter> ().enabled = true; 
				GetComponent<AudioLowPassFilter> ().enabled = true; 
			}
		} 

		else 
		{
			if (GetComponent<AudioSource> ().pitch > 1f)
			{
				GetComponent<AudioSource> ().pitch -= Time.deltaTime; 
				GetComponent<AudioReverbFilter> ().enabled = false; 
				GetComponent<AudioLowPassFilter> ().enabled = false; 
			}
		}
	}
}

