using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpell : MonoBehaviour {

    [SerializeField] private int damage = 10;

	void Start () {
		
	}
	
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            var playerScript = collision.gameObject.GetComponent<HitController>();
            playerScript.TakeDamage(damage);

            Destroy(this);
        }
    }
}
