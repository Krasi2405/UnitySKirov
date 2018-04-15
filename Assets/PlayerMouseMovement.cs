using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouse : MonoBehaviour {

    private Animator animator;
	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();	
	}
	
	// Update is called once per frame
	void Update () {
        float mouseX = Input.mousePosition.x;
        float mouseY = Input.mousePosition.y;
    }
}
