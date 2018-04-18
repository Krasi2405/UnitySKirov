using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Accessibility;

public class DamageController : MonoBehaviour {

    public int maxHp = 100;
    [Range(0, 99)] public float armor = 5f;
    public float missChance = 0.1f;
    public int hp;
    [Range(0, 99)] public float magicReduction;
    public float respawnTime;
    
    [SerializeField] private Transform spawnPoint;

    private void Start()
    {
        hp = maxHp;
    }
    public void TakeDamage(int ammount)
    {
        hp -= ammount;
    }
    public void TakePhysicalHit(int ammount)
    {
        if(UnityEngine.Random.Range(0,1) > missChance)
        {
            float loss = ((100 - armor) / 100) * ammount;
            hp = hp - Mathf.RoundToInt(loss);
        }
        if (CheckDead())
        {
            InitiateDeadSequence();
        }
    }
    public void TakeMagicalDamage(int ammount)
    {
        float loss = ((100 - magicReduction) /100) * ammount;
        hp = hp - Mathf.RoundToInt(loss);
        if (CheckDead())
        {
            InitiateDeadSequence();
        }
    }
    private IEnumerator WaitForRespawn()
    {
        yield return new WaitForSeconds(respawnTime);
    }

    private void InitiateDeadSequence()
    {
        Destroy(gameObject);
        StartCoroutine(WaitForRespawn());
        // drop items
        Instantiate(gameObject);
        transform.position = spawnPoint.position + new Vector3(UnityEngine.Random.Range(0, 10), UnityEngine.Random.Range(0, 10));
        hp = maxHp;
    }

    private bool CheckDead()
    {
        if(hp <= 0) // dead
        {
            return true;
        }
        return false;
    }

}
