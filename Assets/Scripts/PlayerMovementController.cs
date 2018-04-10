using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour {


    [SerializeField] private int movementSpeed = 1;
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
    private void ProcessInput() {
        float xOffset = Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime;
        float yOffset = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;

        animator.SetBool("isWalkingDown", false);
        animator.SetBool("isWalkingUp", false);
        animator.SetBool("isWalkingLeft", false);
        animator.SetBool("isWalkingRight", false);
        if (xOffset > 0) // right
        {
            animator.SetBool("isWalkingRight", true);
            directionSprite = playerRightSprite;
            SetDirectionSprite();
        }
        else if (xOffset < 0) // left
        {

            animator.SetBool("isWalkingLeft", true);
            directionSprite = playerLeftSprite;
            SetDirectionSprite();
        }
        else if (yOffset > 0) // up
        {
            animator.SetBool("isWalkingUp", true);
            directionSprite = playerUpSprite;
            SetDirectionSprite();

        }
        else if (yOffset < 0) // down
        {
            animator.SetBool("isWalkingDown", true);
            directionSprite = playerDownSprite;
            SetDirectionSprite();

        }
        float Xposition = transform.position.x + xOffset;
        float Yposittion = transform.position.y + yOffset;
        transform.position = new Vector2(Xposition, Yposittion);

    }



    public void SetDirectionSprite()
    {
        spriteRenderer.sprite = directionSprite;
    }
}
