using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpellController : MonoBehaviour {

    private Animator animator;

    [SerializeField] private float spellCooldown = 5f;

    private float spellCounter = 0f;

    public GameObject projectileSpell;
    void Start () {
        animator = GetComponent<Animator>();
	}
	

	void Update () {
        spellCounter += Time.deltaTime;
        if (Input.GetButton("Fire1"))
        {
            Debug.Log("Cast a spell");
            CastSpell();
        }
        
	}

    private void CastSpell()
    {
        if(spellCounter >= spellCooldown)
        {
            GameObject projectile = Instantiate(projectileSpell, transform);
            float x = Input.mousePosition.x;
            float y = Input.mousePosition.y;
            projectile.transform.position += new Vector3(transform.position.x + x, transform.position.y + y);
            spellCounter = 0f;
        }
    }
}
