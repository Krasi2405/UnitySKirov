using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {


    public int movementSpeed = 1;

    private Animator animator;

    //private Vector2 direction;

    protected float rawHorizontal = 0f, rawVertical = 0f;


    protected virtual void Start()
    {
        animator = GetComponent<Animator>();
    }

    protected virtual void Update()
    {

    }


    protected void Move(float rawHorizontal, float rawVertical)
    {

        float xOffset = rawHorizontal * movementSpeed * Time.deltaTime;
        float yOffset = rawVertical * movementSpeed * Time.deltaTime;

        float Xposition = transform.position.x + xOffset;
        float Yposittion = transform.position.y + yOffset;

        transform.position = new Vector2(Xposition, Yposittion);

        if (rawHorizontal != 0 || rawVertical != 0)
        {
            AnimateMovement(rawHorizontal, rawVertical);
        }
        else {
            animator.SetLayerWeight(1, 0);
        }
    }

    private void AnimateMovement(float rawHorizontal, float rawVertical)
    {
        animator.SetLayerWeight(1, 1);

        animator.SetFloat("x", rawHorizontal);
        animator.SetFloat("y", rawVertical);
    }

}
