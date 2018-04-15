using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpellController : MonoBehaviour {

    private Animator animator;

    [SerializeField] private float spellCooldown = 5f;

    [SerializeField] private float spellCounter = 4f;

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
            GameObject projectile = Instantiate(projectileSpell);
            Vector3 spellPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            spellPosition.z = 0; // nai veroqtno shtoto kamerata e na -10 i za tui go slaga tam
            projectile.transform.position = transform.position;
            projectile.GetComponent<ProjectileSpell>().direction = Vector3.Normalize(spellPosition - transform.position);
            spellCounter = 0f;
            Destroy(projectile, 2f);
        }
    }
}
