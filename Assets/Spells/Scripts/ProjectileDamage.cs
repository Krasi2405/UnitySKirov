using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDamage : ProjectileSpell {
    [SerializeField] private int health;

    protected override void OnHitBehaviour(GameObject other)
    {
        Debug.Log("Deducting " + health + "hp from " + other);
    }
}
