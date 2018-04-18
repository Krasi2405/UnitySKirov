using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpell : MonoBehaviour {

    public Vector3 direction;
    public float spellDistance;
    [SerializeField] private float speed = 10;

    private Vector2 start;

    private void Start()
    {
        start = transform.position;
    }

    void Update () {
        transform.position += direction * Time.deltaTime * speed;
        if(Vector2.Distance(transform.position, start) > spellDistance)
        {
            Destroy(gameObject);
        }
	}

}
