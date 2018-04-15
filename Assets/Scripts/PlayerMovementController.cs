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
    private Animator bodyAnimator;
    [SerializeField] private Transform bodyTransform;

    private bool isInIdle = true;



    void Start () {
        spriteRenderer = bodyTransform.GetComponent<SpriteRenderer>();
        bodyAnimator = bodyTransform.GetComponent<Animator>();
        directionSprite = playerDownSprite;
	}
	

	void Update () {
        ProcessInput();
	}
    private void ProcessInput() {
        float rawHorizontal = Input.GetAxis("Horizontal");
        float rawVertical = Input.GetAxis("Vertical");
        float xOffset = rawHorizontal * movementSpeed * Time.deltaTime;
        float yOffset = rawVertical * movementSpeed * Time.deltaTime;
        Debug.Log("Input x, y: " + Input.GetAxis("Horizontal") + ", " + Input.GetAxis("Vertical"));

        bodyAnimator.SetBool("isWalkingDown", false);
        bodyAnimator.SetBool("isWalkingUp", false);
        bodyAnimator.SetBool("isWalkingLeft", false);
        bodyAnimator.SetBool("isWalkingRight", false);
        isInIdle = false;
        if (rawHorizontal > 0 && rawHorizontal >= rawVertical) // right
        {
            bodyAnimator.SetBool("isWalkingRight", true);
            directionSprite = playerRightSprite;
        }
        else if (rawHorizontal < 0 && rawHorizontal <= rawVertical) // left
        {

            bodyAnimator.SetBool("isWalkingLeft", true);
            directionSprite = playerLeftSprite;
        }
        else if (rawVertical > 0 && rawVertical > rawHorizontal) // up
        {
            bodyAnimator.SetBool("isWalkingUp", true);
            directionSprite = playerUpSprite;

        }
        else if (rawVertical < 0 && rawVertical < rawHorizontal) // down
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
