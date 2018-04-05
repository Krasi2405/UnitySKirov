using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour {

    private bool isWalkingUp;
    private bool isWalkingDown;
    private bool isWalkingLeft;
    private bool isWalkingRight;
    [SerializeField] private Sprite playerLeftSprite;
    [SerializeField] private Sprite playerRightSprite;
    [SerializeField] private Sprite playerUpSprite;
    [SerializeField] private Sprite playerDownSprite;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        ProcessInput();
	}

    private void ProcessInput()
    {
        if (Input.GetKeyDown("W")) {
            isWalkingUp = true;
            spriteRenderer.sprite = playerUpSprite;
            animator.SetBool("isWalkingUp", true);
        }
        if (Input.GetKeyDown("S"))
        {
            isWalkingDown = true;
            spriteRenderer.sprite = playerDownSprite;
            animator.SetBool("isWalkingDown", true);
        }
        if (Input.GetKeyDown("A"))
        {
            isWalkingLeft = true;
            spriteRenderer.sprite = playerLeftSprite;
            animator.SetBool("isWalkingLeft", true);
        }
        if (Input.GetKeyDown("D"))
        {
            isWalkingRight = true;
            spriteRenderer.sprite = playerRightSprite;
            animator.SetBool("isWalkingRight", true);
        }


        if (Input.GetKeyUp("W"))
        {
            isWalkingUp = false;
            animator.SetBool("isWalkingUp", false);
        }
        if (Input.GetKeyUp("S"))
        {
            isWalkingDown = false;
            animator.SetBool("isWalkingDown", false);
        }
        if (Input.GetKeyUp("A"))
        {
            isWalkingLeft = false;
            animator.SetBool("isWalkingLeft", false);
        }
        if (Input.GetKeyUp("D"))
        {
            isWalkingRight = false;
            animator.SetBool("isWalkingRight", false);
        }
    }
}
