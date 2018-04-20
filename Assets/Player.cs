using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

public class Player : Character
{
    [SerializeField] private Stat healthbar;
    [SerializeField] private Stat manabar;
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
        if (rawHorizontal != 0 || rawVertical != 0)
        {
            Move(rawHorizontal, rawVertical);
        }

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
        rawHorizontal = Input.GetAxisRaw("Horizontal");
        rawVertical = Input.GetAxis("Vertical");
    }
}
