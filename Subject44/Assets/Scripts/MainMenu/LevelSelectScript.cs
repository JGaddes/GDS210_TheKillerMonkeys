using UnityEngine;
using System.Collections;

public class LevelSelectScript : MonoBehaviour {

    private int worldIndex;
    private int levelIndex;   
	
	void  Start (){
		//loop thorugh all the worlds
		for(int i = 1; i <= LockLevel.worlds; i++){
			if(Application.loadedLevelName == "MainMenu"+i){
				worldIndex = i;
				CheckLockedLevels(); 
			}
		}
	}
	
	//Level to load on button click. Will be used for Level button click event 
	public void Selectlevel(string worldLevel){
		Application.LoadLevel("Level"+worldLevel); //load the level
	}
	

	public void  Update (){
  		if (Input.GetKeyDown(KeyCode.Escape) ){
			Application.LoadLevel("MainMenu1");
			PlayerPrefs.Save ();
  		} 

 	}
	
	//function to check for the levels locked
	void  CheckLockedLevels (){
		//loop through the levels of a particular world
		for(int j = 1; j < LockLevel.levels; j++){
			levelIndex = (j+1);
			if((PlayerPrefs.GetInt("level"+worldIndex.ToString() +":" +levelIndex.ToString()))==1){
				GameObject.Find("LockedLevel"+(j+1)).SetActive (false);
				Debug.Log ("Unlocked Level " + levelIndex);
			}
		}
	}
}