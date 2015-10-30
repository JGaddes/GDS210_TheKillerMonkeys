using UnityEngine;
using System.Collections;

public class TextShow : MonoBehaviour {

    public GameObject tutorialText;
    public float waitTime = 10f;


    public void CallText()
    {
       StartCoroutine(ShowText());
    }

    IEnumerator ShowText()
    {
        tutorialText.SetActive(true);
        yield return new WaitForSeconds(waitTime);
        tutorialText.SetActive(false);
    }
}
