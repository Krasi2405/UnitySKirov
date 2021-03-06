﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackController : MonoBehaviour {

    
    public int spinAttackRange = 10;
    public int spinAttackDamage = 10;

    public int basicAttackRange = 10;
    public int basicAttackDamage = 10;

    private Animator animator;

    void Start () {
        animator = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        if (Input.GetButton("Fire1"))
        {
            SpinAttack();
        }
        if (Input.GetButton("Fire2"))
        {
            BasicAttack(horizontal, vertical);
        }
    }

    private void BasicAttack(float xDir, float yDir)
    {
        Vector2 start = transform.position;
        float directionX = Mathf.Clamp(Input.mousePosition.x, -basicAttackRange, basicAttackRange);
        float directionY = Mathf.Clamp(Input.mousePosition.x, -basicAttackRange, basicAttackRange);
        //int x = Mathf.CeilToInt(xDir);
        //int y = Mathf.CeilToInt(yDir);

        Vector2 end = start + new Vector2(directionX, directionY);
        RaycastHit2D result = Physics2D.Linecast(start, end);
        if (result.transform.tag == "Enemy")
        {

            var enemyScript = result.transform.GetComponent<DamageController>();
            enemyScript.TakePhysicalHit(basicAttackDamage);
        }
    }
    private void SpinAttack()
    {
        RaycastHit2D[] results;
        Vector2 origin = transform.position;
        results = Physics2D.CircleCastAll(origin, spinAttackRange, origin);

        foreach (RaycastHit2D result in results)
        {
            if (result.transform.tag == "Enemy" || result.transform.tag == "Player")
            {
                var enemyScript = result.transform.GetComponent<DamageController>();
                enemyScript.TakePhysicalHit(spinAttackDamage);
            }
        }
    }

}
