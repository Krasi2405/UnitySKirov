﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDamage : ProjectileSpell {
    [SerializeField] private int damage;

    protected override void OnHitBehaviour(GameObject other)
    {
        if (other.tag == "Player") return;
        Debug.Log("Dealing " + damage + " damage to enemy");
        other.GetComponent<Enemy>().TakeMagicalDamage(damage);
        Destroy(gameObject);
    }
}
