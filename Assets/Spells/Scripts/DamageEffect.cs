using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEffect : SpellEffect {


    [SerializeField] private int damage;

    protected override void EffectBehaviour(Character target)
    {
        target.TakeMagicalDamage(damage);
        Debug.Log(target + " took " + damage + " magical damage!");
    }
}
