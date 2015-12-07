using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class GuiScript : MonoBehaviour {
	
	public PlayerController playerController;
	public int count;
	public float cooldown = 2;
    public Image idCardUI;
    private bool isShowing;

    void Start () {

        idCardUI.enabled = false;

    }

    public void IDActive() {

        isShowing = !isShowing;
        idCardUI.enabled = isShowing;
    }

    public void IDUnactive() {

       
    }
    
}