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
    [SerializeField] private SpellBook spellbook;


    protected override void Start()
    {
        base.Start();
        currentHp = maxHp;
        currentMana = maxMana;
        /*
        healthbar.InitStat(currentHp, maxHp);
        manabar.InitStat(currentMana, maxMana);
        */

        spellbook = GetComponent<SpellBook>();
        if(spellbook == null)
        {
            Debug.Log("No spellbook???");
        }
        else
        {
            Debug.Log("instantiate spellbook!");
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
        if (Input.GetKeyDown(KeyCode.E))
        {
            StopCast();
        }
        float rawHorizontal = Input.GetAxisRaw("Horizontal");
        float rawVertical = Input.GetAxisRaw("Vertical");
        direction = new Vector2(rawHorizontal, rawVertical);
    }

    
    private IEnumerator CastAnimation(SpellBehaviour spell)
    {
        isCasting = true;
        animator.SetBool("isCasting", true);
        yield return new WaitForSeconds(spell.castTime);
        Cast(spell);
        StopCast();
    }

    private void Cast(SpellBehaviour spell)
    {
        SpellBehaviour spellInstantiation = Instantiate(spell, transform.position , Quaternion.identity).GetComponent<SpellBehaviour>();
        spellInstantiation.ActivateSpell();
    }

    public void CastSpell(int spellIndex)
    {
        if (isCasting) return;
        
        SpellBehaviour spell = spellbook.CastSpell(spellIndex);
        if (!isMoving && spell)
        {
            castRoutine = StartCoroutine(CastAnimation(spell));
        }      
    }
}
