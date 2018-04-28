using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellScript : MonoBehaviour {

    private Rigidbody2D rigidbody;
    [SerializeField] private float speed;
    public Vector2 mousePosition;
    private Vector2 direction = Vector2.zero;
    [SerializeField] private float range;
    private Vector2 start;

	void Start () {
        rigidbody = GetComponent<Rigidbody2D>();
        
        start = rigidbody.position;
    }
	

    public void SetDirection(Vector2 mousePosition)
    {
        direction = mousePosition - (Vector2)transform.position;
    }


    private void FixedUpdate()
    {
        if(Vector2.Distance(start, rigidbody.position) > range)
        {
            Destroy(gameObject);
        }

        if (direction != Vector2.zero)
        {
            transform.Translate(direction.normalized * speed * Time.deltaTime);
        }
        else
        {
            Debug.LogError("WTF??? Set the direction my nigga!");
        }
        /*
        rigidbody.velocity = direction.normalized * speed;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        */
    }
}
