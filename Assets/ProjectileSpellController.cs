using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpellController : MonoBehaviour {

    private Animator animator;

    [SerializeField] private float firstSpellCooldown = 5f;
    [SerializeField] private float secondSpellCooldown = 5f;
    [SerializeField] private float thirdSpellCooldown = 5f;

    private float firstSpellCounter = 0f;
    private float secondSpellCounter = 0f;
    private float thirdSpellCounter = 0f;

    void Start () {
        animator = GetComponent<Animator>();
	}
	

	void Update () {
        firstSpellCounter += Time.deltaTime;
        secondSpellCounter += Time.deltaTime;
        thirdSpellCounter += Time.deltaTime;
        if (Input.GetButton("Fire3"))
        {
            CastSpell();
        }
        
	}

    private void CastSpell()
    {
        if(firstSpellCounter >= firstSpellCooldown)
        {
            //Instantiate(PlayerFirstSpell, transform.position);
            firstSpellCounter = 0f;
        }
    }
}
