using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellController : MonoBehaviour {

    private Animator animator;

    [SerializeField] private float firstSpellCooldown = 5f;
    private float firstSpellCounter = 0f;

    [SerializeField] private float secondSpellCooldown = 5f;
    private float secondSpellCounter = 0f;

    [SerializeField] private float thirdSpellCooldown = 5f;
    private float thirdSpellCounter = 0f;

    [SerializeField] private float firstSpellCastRange = 5f;
    [SerializeField] private float secondSpellCastRange = 5f;
    [SerializeField] private float thirdSpellCastRange = 5f;

    public GameObject projectileSpell;
    void Start () {
        animator = GetComponent<Animator>();
	}
	

	void Update () {
        firstSpellCounter += Time.deltaTime;
        secondSpellCounter += Time.deltaTime;
        thirdSpellCounter += Time.deltaTime;

        if (Input.GetButton("Fire1"))
        {
            //Debug.Log("Cast a projectile spell");
            CastProjectileSpell();
        }
        if (Input.GetButton("Fire2"))
        {
           // Debug.Log("Cast an AoE sppell");

        }
        if (Input.GetButton("Fire3"))
        {
          //  Debug.Log("Cast point and cast spell");
        }
    }

    private void CastProjectileSpell()
    {
        if(firstSpellCounter >= firstSpellCooldown)
        {
        
            Vector3 spellPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            float distance = Vector2.Distance(spellPosition, transform.position);
            Debug.Log("distance: " + distance + " spell position: " + spellPosition);
            if (distance <= firstSpellCastRange)
            {
                GameObject projectile = Instantiate(projectileSpell);
                spellPosition.z = 0; // nai veroqtno shtoto kamerata e na -10 i za tui go slaga tam
                projectile.transform.position = transform.position;
                projectile.GetComponent<ProjectileSpell>().direction = Vector3.Normalize(spellPosition - transform.position);
                firstSpellCounter = 0f;
            }
        }
    }
}
