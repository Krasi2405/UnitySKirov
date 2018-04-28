﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {


    public int movementSpeed = 1;

    protected Animator animator;

    protected Rigidbody2D rigidbody;

    protected Vector2 direction;

    protected Coroutine castRoutine;
    protected Coroutine moveRoutine;


    protected bool isMoving {
        get
        {
            return direction.x != 0 || direction.y != 0;
        }
    }
    protected bool isPlayerMoving
    {
        get
        {
            return Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0;
        }
    }
    protected bool isCasting = false;

    protected virtual void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    protected virtual void Update()
    {
        HandleLayers();
        HandleCoroutines();
    }

    private void HandleCoroutines()
    {
        if (isPlayerMoving)
        {
            StopMoveRoutine();
        }
        if (isMoving)
        {
            StopCast();
        }
    }

    private void FixedUpdate()
    {
        Move();   
    }
    public void HandleLayers()
    {
        if (isMoving)
        {
            ActivateLayer("walk");
            animator.SetFloat("x", direction.x);
            animator.SetFloat("y", direction.y);

        }
        else if (isCasting)
        {
            ActivateLayer("cast");
        }
        else
        {
            ActivateLayer("idle");
        }
    }

    protected void Move()
    {
        rigidbody.velocity = direction.normalized * movementSpeed;
    }

    private void ActivateLayer(string layerName)
    {
        for(int i = 0; i < animator.layerCount; i++)
        {
            animator.SetLayerWeight(i, 0);
        }
        animator.SetLayerWeight(animator.GetLayerIndex(layerName), 1);
    }

    public void StopCast()
    {
        if (castRoutine != null)
        {
            isCasting = false;
            StopCoroutine(castRoutine);
            animator.SetBool("isCasting", false);
        }
    }

    protected IEnumerator MoveTowards(Vector2 finish)
    {
        //* GOVNO KOD INCOMING *//
        // - Brace yourselves //
        //* tutututututu tutututu tututu */
        /*
        //rigidbody.position = Vector2.MoveTowards(rigidbody.position, finish, movementSpeed);
        float remainingDistance = Vector2.Distance(finish, rigidbody.position);
        while(remainingDistance > Mathf.Epsilon)
        {
            direction = finish - rigidbody.position;
            //rigidbody.velocity = direction.normalized * movementSpeed;
            remainingDistance = Vector2.Distance(finish, rigidbody.position);
            yield return null;

        }
        StopMoveRoutine(); */
        // - Phew your earned yourselves a breather //
        // - Use that time wisely
        StopCoroutine("MoveTowards");
        float distance = Vector2.Distance(transform.position, finish);
        float time = distance / movementSpeed;
        float currentTime = 0;
        Vector2 startPosition = transform.position;
        Vector2 lastFramePos = startPosition;
        while(currentTime <= time)
        {
            currentTime += Time.deltaTime;
            Vector2 movedDistance = Vector2.Lerp(startPosition, finish, currentTime / time);
            rigidbody.MovePosition(movedDistance);

            direction = movedDistance - lastFramePos; // manual set direction
            lastFramePos = movedDistance;
            
            Debug.Log("Velocity: " + rigidbody.velocity);
            yield return new WaitForEndOfFrame();
        }
        


    }

    public void StopMoveRoutine()
    {
        if(moveRoutine != null)
        {
            direction = Vector2.zero;
            StopCoroutine(moveRoutine);
        }
    }
}
