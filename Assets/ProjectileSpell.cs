using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpell : MonoBehaviour {

    [SerializeField] private int damage = 10;
    public Vector3 direction;
    [SerializeField] private float speed = 10;

	void Start () {
		
	}
	
	void Update () {
        transform.position += direction * Time.deltaTime * speed;
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            var enemyScript = collision.gameObject.GetComponent<HitController>();
            enemyScript.TakeDamage(damage);
            Destroy(this);
        }
    }
}
