using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DPSEffect : SpellEffect
{
    [SerializeField] private float dps = 5f;

    protected override void EffectBehaviour(Character target)
    {
        float damage = Time.deltaTime / dps;
        Debug.Log("Dealing " + damage + " to " + target);
        target.TakeMagicalDamage(damage);
    }
}
