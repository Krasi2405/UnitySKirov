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
    

    protected override void Start()
    {
        base.Start();
        currentHp = maxHp;
        currentMana = maxMana;

        healthbar.InitStat(currentHp, maxHp);
        manabar.InitStat(currentMana, maxMana);
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

    private IEnumerator Cast(int spellIndex)
    {
        isCasting = true;
        animator.SetBool("isCasting", true);
        

        yield return new WaitForSeconds(1);

        Instantiate(spellPrefab[spellIndex], transform.position, Quaternion.identity);

        Debug.Log("Done casting");

        StopCast();

    }

    public void CastSpell(int spellIndex)
    {

        if (!isMoving && !isCasting)
        {
            castRoutine = StartCoroutine(Cast(spellIndex));
        }
       
    }
}
