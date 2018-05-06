using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserStreamSpell : SpellBehaviour {

    [SerializeField] GameObject laserPrefab;


    protected override void TurnOnBehaviour()
    {
        Instantiate(laserPrefab);
    }

    protected override bool CastConditionsFulfilled()
    {
        return true;
    }
}
