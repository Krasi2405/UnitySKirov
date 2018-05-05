using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpellEffect : MonoBehaviour {
    
    public void ApplyEffect(Character target)
    {
        EffectBehaviour(target);
    }

    protected abstract void EffectBehaviour(Character target);
}
