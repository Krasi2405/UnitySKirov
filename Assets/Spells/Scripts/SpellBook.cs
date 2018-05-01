using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellBook : MonoBehaviour {

    [SerializeField] private SpellBehaviour[] spells;

    private void Update()
    {
        for(int i = 0; i < spells.Length; i++)
        {
            if (spells[i].currentCooldown >= Mathf.Epsilon)
            {
                spells[i].currentCooldown -= Time.deltaTime;
            }
        }
    }


    public SpellBehaviour CastSpell(int index)
    {
        SpellBehaviour spell = spells[index];
        if (spell.CanCast())
        {
            spell.currentCooldown = spell.cooldown;
            return spells[index];
        }
        else
        {
            return null;
        }
    }
}
