using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

public class Player : Character
{
    [SerializeField] private Stat healthbar;
    [SerializeField] private Stat manabar;
    private Vector2 mousePosition;

    public int maxHp = 500;
    public int maxMana = 200;

    private int currentMana;
    private int currentHp;
    private SpellBook spellbook;


    protected override void Start()
    {
        base.Start();
        currentHp = maxHp;
        currentMana = maxMana;

        healthbar.InitStat(currentHp, maxHp);
        manabar.InitStat(currentMana, maxMana);

        spellbook = GetComponent<SpellBook>();

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
        if (Input.GetKeyDown(KeyCode.E))
        {
            StopCast();
        }
        float rawHorizontal = Input.GetAxisRaw("Horizontal");
        float rawVertical = Input.GetAxisRaw("Vertical");
        direction = new Vector2(rawHorizontal, rawVertical);
    }

    private IEnumerator CastAnimation(Spell spell)
    {
        isCasting = true;
        animator.SetBool("isCasting", true);
        yield return new WaitForSeconds(spell.CastTime);
        Cast(spell);
        StopCast();

    }

    private void Cast(Spell spell)
    {
        spell.LastCasted = Time.time;

        SpellScript spellScript = Instantiate(spell.Prefab , transform.position , Quaternion.identity).GetComponent<SpellScript>();
        spellScript.mousePosition = mousePosition;
    }

    public void CastSpell(int spellIndex)
    {
        if (isCasting) return;

        Spell spell = spellbook.CastSpell(spellIndex);

        mousePosition = Camera.main.WorldToScreenPoint(Input.mousePosition);
        //TODO: distance not calculated properly
        float distance = Vector2.Distance(mousePosition, rigidbody.position);
        Debug.Log(distance);
        float timeSinceLastCast = Time.time - spell.LastCasted;

        if(spell.HasCastRange && distance > spell.CastRange)
        {
            Debug.Log("Move to mouse position");
            
            moveRoutine = StartCoroutine(MoveTowards(mousePosition));
        }

        else if (!isMoving && timeSinceLastCast >= spell.Cooldown)
        {
            castRoutine = StartCoroutine(CastAnimation(spell));
        }
       
    }
}
