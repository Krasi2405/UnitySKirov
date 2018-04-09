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
    private Sprite directionSprite;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
	}
	

	void Update () {
        ProcessInput();
	}

    private void ProcessInput()
    {
        if (Input.GetKey(KeyCode.A))
        {
            spriteRenderer.sprite = playerLeftSprite;
            animator.SetBool("isWalkingLeft", true);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            spriteRenderer.sprite = playerRightSprite;
            animator.SetBool("isWalkingRight", true);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            spriteRenderer.sprite = playerDownSprite;
            animator.SetBool("isWalkingDown", true);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            spriteRenderer.sprite = playerUpSprite;
            animator.SetBool("isWalkingUp", true);
        }



        if (Input.GetKeyUp(KeyCode.W))
        {
            directionSprite = playerUpSprite;
            animator.SetBool("isWalkingUp", false);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            directionSprite = playerDownSprite;
            animator.SetBool("isWalkingDown", false);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            directionSprite = playerLeftSprite;
            animator.SetBool("isWalkingLeft", false);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            directionSprite = playerRightSprite;
            animator.SetBool("isWalkingRight", false);
        }
        

    }


    public void SetDirectionSprite()
    {
        GetComponent<SpriteRenderer>().sprite = directionSprite;
    }
}
