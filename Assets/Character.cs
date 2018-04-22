using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {


    public int movementSpeed = 1;

    private Animator animator;

    private Rigidbody2D rigidbody;

    protected Vector2 direction;

    protected bool isMoving {
        get
        {
            return direction.x != 0 || direction.y != 0;
        }
    }

    protected virtual void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    protected virtual void Update()
    {
        HandleLayers();
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


}
