using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDamage : ProjectileSpell {
    [SerializeField] private int damage;

    protected override void OnHitBehaviour(GameObject other)
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        other.GetComponent<Enemy>().TakeMagicalDamage(damage);
        Destroy(gameObject);
    }
}
