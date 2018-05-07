using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserStreamSpell : SpellBehaviour {

    [SerializeField] private float duration;

    private void Update()
    {
        transform.position = spellCaster.transform.position;

        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 offset = mousePosition - (Vector2)spellCaster.transform.position;

        // Set rotation
        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, angle);
    }

    protected override void TurnOnBehaviour()
    {
        Invoke("EndSpell", duration);
    }

    private void EndSpell()
    {
        GetComponent<Animator>().SetTrigger("StopStream");
    }

    private void DestroySpell()
    {
        Destroy(gameObject);
    }

    protected override bool CastConditionsFulfilled()
    {
        return true;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        Character character = other.GetComponent<Character>();

        
        if (character && character != spellCaster) {
            Debug.Log(character);
            ApplyAllEffects(character);
        }
    }
}
