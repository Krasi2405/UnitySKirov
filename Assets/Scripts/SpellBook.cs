using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellBook : MonoBehaviour {

    [SerializeField] private Spell[] spells;

    private void Start()
    {
        for(int i = 0; i< spells.Length; i++)
        {
            spells[i].LastCasted = Time.time;
        }
    }

    public Spell CastSpell(int index)
    {

        return spells[index];
    }
}
