using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpellController : MonoBehaviour {

    private Animator animator;

    [SerializeField] private float spellCooldown = 5f;

    private float spellCounter = 0f;

    void Start () {
        animator = GetComponent<Animator>();
	}
	

	void Update () {
        spellCounter += Time.deltaTime;
        if (Input.GetButton("Fire3"))
        {
            CastSpell();
        }
	}

    private void CastSpell()
    {
        if(spellCounter >= spellCooldown)
        {
            // TODO: instantiate spell and give it velocity
            spellCounter = 0f;
        }
    }
}
