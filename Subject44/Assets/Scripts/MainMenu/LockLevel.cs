using UnityEngine;
using System.Collections;

public class LockLevel : MonoBehaviour {

    public static int worlds = 1;
    public static int levels = 3;

	private int worldIndex;
	private int levelIndex;

	// Use this for initialization
	void Start () {
	
		PlayerPrefs.DeleteAll (); //erase data on start
		LockLevels (); // Call funtion LockLevels
	}

	void LockLevels(){
	
		for (int i = 0; i < worlds; i++){
			for (int j = 1; j < levels; j++){
				worldIndex  = (i+1);
				levelIndex  = (j+1);
				//create a PlayerPrefs of that particular level and world and set it's to 0, if no key of that name exists
				if(!PlayerPrefs.HasKey("level"+worldIndex.ToString() +":" +levelIndex.ToString())){
					PlayerPrefs.SetInt("level"+worldIndex.ToString() +":" +levelIndex.ToString(),0);
				}				
			}
		}
	}
}
