using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class CodeScript : MonoBehaviour {
	
	public List<GameObject> unlockables;
    public string currentLevel;
    private int worldIndex;
    private int levelIndex;
	private int setIndex;

	void Start (){

		var input = gameObject.GetComponent<InputField>();
		var se= new InputField.SubmitEvent();
		se.AddListener(CodeCheck);
		input.onEndEdit = se;
	}

	private void CodeCheck(string other){

        switch (other.ToLower()) {
		
		case "bacon":
			    //Unlocks Levels up to level 2
			    unlockables[0].gameObject.GetComponent<Image>().enabled = false;
				setIndex = 2;
                UnlockLevel();
                break;
		case "sauce":
                //Unlocks Levels up to level 3
                unlockables[0].gameObject.GetComponent<Image>().enabled = false;
                unlockables[1].gameObject.GetComponent<Image>().enabled = false;
				setIndex = 3;
                UnlockLevel();
                break;
		default:
			    Debug.Log ("Wrong Code Nerd!");
			    break;
		}
	}


    public void UnlockLevel()
    {

        for (int i = 0; i < LockLevel.worlds; i++)
        {

			for (int j = 1; j < setIndex; j++)
            {

                worldIndex = (i + 1);
				levelIndex = (j + 1);
                PlayerPrefs.SetInt("level" + worldIndex.ToString() + ":" + levelIndex.ToString(), 1);
            }
        }
    }
}
