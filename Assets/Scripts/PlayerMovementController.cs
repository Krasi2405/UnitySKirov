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
    [SerializeField] private Animator bodyAnimator;

    private bool isInIdle = true;



    void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        directionSprite = playerDownSprite;
	}
	

	void Update () {
        ProcessInput();
	}
    private void ProcessInput() {
        float xOffset = Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime;
        float yOffset = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;

        bodyAnimator.SetBool("isWalkingDown", false);
        bodyAnimator.SetBool("isWalkingUp", false);
        bodyAnimator.SetBool("isWalkingLeft", false);
        bodyAnimator.SetBool("isWalkingRight", false);
        isInIdle = false;
        if (xOffset > 0) // right
        {
            bodyAnimator.SetBool("isWalkingRight", true);
            directionSprite = playerRightSprite;
        }
        else if (xOffset < 0) // left
        {

            bodyAnimator.SetBool("isWalkingLeft", true);
            directionSprite = playerLeftSprite;
        }
        else if (yOffset > 0) // up
        {
            bodyAnimator.SetBool("isWalkingUp", true);
            directionSprite = playerUpSprite;

        }
        else if (yOffset < 0) // down
        {
            bodyAnimator.SetBool("isWalkingDown", true);
            directionSprite = playerDownSprite;
            
        }
        else
        {
            isInIdle = true;
        }
        float Xposition = transform.position.x + xOffset;
        float Yposittion = transform.position.y + yOffset;
        transform.position = new Vector2(Xposition, Yposittion);
    }

    public void LateUpdate()
    {
        if (isInIdle)
        {
            SetDirectionSprite();
        }
    }



    public void SetDirectionSprite()
    {
        spriteRenderer.sprite = directionSprite;
    }
}
