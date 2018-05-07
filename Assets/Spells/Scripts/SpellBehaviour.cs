using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class SpellBehaviour : MonoBehaviour {

    
    [SerializeField] public Sprite icon;
    [SerializeField] public float cooldown;
    [SerializeField] public float castTime;
    [SerializeField] public Character spellCaster { get; private set; }

    public int index;

    public float currentCooldown = 0;

    public void ActivateSpell(Character caster)
    {
        spellCaster = caster;
        TurnOnBehaviour();
    }

    
    protected abstract void TurnOnBehaviour();
    protected abstract bool CastConditionsFulfilled();


    public bool CanCast()
    {
        return currentCooldown <= 0 && CastConditionsFulfilled();
    }


    public void ApplyAllEffects(Character target)
    {
        foreach(SpellEffect effect in GetComponents<SpellEffect>())
        {
            effect.ApplyEffect(target);
        }
    }

}