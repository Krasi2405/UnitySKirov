using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class SpellBehaviour : MonoBehaviour {

    [SerializeField] public Sprite icon;
    [SerializeField] public float cooldown;
    [SerializeField] public float castTime;

    public int index;

    public float currentCooldown = 0;

    public void ActivateSpell()
    {
        TurnOnBehaviour();
    }

    
    protected abstract void TurnOnBehaviour();

    
    protected abstract bool CastConditionsFulfilled();
    public bool CanCast()
    {
        return currentCooldown <= 0 && CastConditionsFulfilled();
    }

}
