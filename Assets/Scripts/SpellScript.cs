using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellScript : MonoBehaviour {

    private Rigidbody2D rigidbody;
    [SerializeField] private float speed;
    public Vector2 mousePosition;
    private Vector2 direction;


	void Start () {
        
        rigidbody = GetComponent<Rigidbody2D>();
        direction = mousePosition - (Vector2)transform.position;
    }
	


    private void FixedUpdate()
    {
        rigidbody.velocity = direction.normalized * speed;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
