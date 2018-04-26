using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UImanager : MonoBehaviour {
    [SerializeField] private Button[] buttons;
    private KeyCode spell1, spell2, spell3, spell4;
    private int buttonIndex;
	void Start () {
        spell1 = KeyCode.Alpha1;
        spell2 = KeyCode.Alpha2;
        spell3 = KeyCode.Alpha3;
        spell4 = KeyCode.Alpha4;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(spell1))
        {
            SpellButtonOnClick(0);
        }
        if (Input.GetKeyDown(spell2))
        {
            SpellButtonOnClick(1);
        }
        if (Input.GetKeyDown(spell3))
        {
            SpellButtonOnClick(2);
        }
        if (Input.GetKeyDown(spell4))
        {
            SpellButtonOnClick(3);
        }
    }

    private void SpellButtonOnClick(int buttonIndex)
    {
        buttons[buttonIndex].onClick.Invoke();
    }
}
