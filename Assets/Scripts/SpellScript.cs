using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellScript : MonoBehaviour {

    private Rigidbody2D rigidbody;
    [SerializeField] private float speed;
    public Vector2 mousePosition;
    private Vector2 direction;
    [SerializeField] private float range;
    private Vector2 start;

	void Start () {
        
        rigidbody = GetComponent<Rigidbody2D>();
        direction = mousePosition - (Vector2)transform.position;
        start = rigidbody.position;
    }
	


    private void FixedUpdate()
    {
        if(Vector2.Distance(start, rigidbody.position) > range)
        {
            Destroy(gameObject);
        }
        rigidbody.velocity = direction.normalized * speed;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
