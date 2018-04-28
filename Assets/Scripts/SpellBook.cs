using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellBook : MonoBehaviour {

    [SerializeField] private Spell[] spells;

    private void Start()
    {
        for (int i = 0; i < spells.Length; i++)
        {
            spells[i].CurrentCooldown = 0;
        }
    }

    private void Update()
    {
        for(int i = 0; i< spells.Length; i++)
        {
            spells[i].CurrentCooldown -= Time.deltaTime;
        }
    }
    public Spell CastSpell(int index)
    {

        return spells[index];
    }
}
