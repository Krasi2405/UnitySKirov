using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitController : MonoBehaviour {

    public int hp = 100;
    [Range(0, 100)] public float armor = 5f;
    public float missChance = 0.1f;

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void TakeDamage(int ammount)
    {
        hp -= ammount;
    }
    public void TakeHit(int ammount)
    {
        if(Random.Range(0,1) > missChance)
        {
            float loss = (armor % 100) * ammount;
            hp = hp - Mathf.RoundToInt(loss);
        }
    }
}
