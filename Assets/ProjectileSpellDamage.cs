using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpellDamage : ProjectileSpell {

    [SerializeField] private int damage = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            var enemyScript = collision.gameObject.GetComponent<DamageController>();
            enemyScript.TakeMagicalDamage(damage);
            Destroy(gameObject);
        }
    }

}
