using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ProjectileSpell : SpellBehaviour {

    [SerializeField] public float speed;
    [SerializeField] public float range;

    protected override void TurnOnBehaviour()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 offset = mousePosition - (Vector2)transform.position;

        // Set rotation
        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, angle);
        
        // Set velocity
        GetComponent<Rigidbody2D>().velocity = offset.normalized * speed;

        //destroy after it travels certain distance
        Destroy(gameObject, range / speed); // S = v * t => t = S/v ; lifetime of the spell
        
    }

    protected override bool CastConditionsFulfilled()
    {
        // TODO @Kirov:
        // Ako ti se zanimava implementni range tuka. Mene me murzi
        return true;
    }

    protected abstract void OnHitBehaviour(GameObject other);

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Projectile spellHit");
        OnHitBehaviour(other.gameObject);
    }

}
