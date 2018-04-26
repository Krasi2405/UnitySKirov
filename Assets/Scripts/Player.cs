using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

public class Player : Character
{
    [SerializeField] private Stat healthbar;
    [SerializeField] private Stat manabar;
    [SerializeField] GameObject[] spellPrefab;

    public int maxHp = 500;
    public int maxMana = 200;

    private int currentMana;
    private int currentHp;
    private float[] lastCasted = new float[4];

    public float[] spellCooldown;
    public float[] castRange;
    public float[] castTime;

    protected override void Start()
    {
        base.Start();
        currentHp = maxHp;
        currentMana = maxMana;

        healthbar.InitStat(currentHp, maxHp);
        manabar.InitStat(currentMana, maxMana);
        for(int i = 0; i < lastCasted.Length; i++)
        {
            lastCasted[i] = Time.time;
        }
    }


    protected override void Update()
    {
        base.Update();

        GetInput();


    }


    private void GetInput()
    {
        // for debuging
        if (Input.GetKey(KeyCode.I))
        {
            currentHp -= 10;
            currentMana -= 10;
            healthbar.SetCurrentAmount(currentHp);
            manabar.SetCurrentAmount(currentMana);
        }
        if (Input.GetKey(KeyCode.O))
        {
            currentHp += 10;
            currentMana += 10;
            healthbar.SetCurrentAmount(currentHp);
            manabar.SetCurrentAmount(currentMana);
        }
        if (Input.GetButtonDown("Fire1"))
        {
            CastSpell(0);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            StopCast();
        }
        float rawHorizontal = Input.GetAxisRaw("Horizontal");
        float rawVertical = Input.GetAxisRaw("Vertical");
        direction = new Vector2(rawHorizontal, rawVertical);
    }

    private IEnumerator CastAnimation(int spellIndex)
    {
        isCasting = true;
        animator.SetBool("isCasting", true);
        

        yield return new WaitForSeconds(castTime[spellIndex]);
        Cast(spellIndex);

        Debug.Log("Done casting");

        StopCast();

    }

    private void Cast(int spellIndex)
    {
        lastCasted[spellIndex] = Time.time;
        Instantiate(spellPrefab[spellIndex], transform.position, Quaternion.identity);
    }

    public void CastSpell(int spellIndex)
    {
        Vector2 mousePosition = Camera.main.WorldToScreenPoint(Input.mousePosition);
        float distance = Vector2.Distance(transform.position, mousePosition);
        float timeSinceLastCast = Time.time - lastCasted[spellIndex];
        if(distance > castRange[spellIndex])
        {
            direction = mousePosition - (Vector2)transform.position;
            Move();
        }

        else if (!isMoving && !isCasting && timeSinceLastCast >= spellCooldown[spellIndex])
        {
            castRoutine = StartCoroutine(CastAnimation(spellIndex));
        }
       
    }
}
