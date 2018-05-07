using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomizationManager : MonoBehaviour {

    Sprite[] bodylayer;
    Sprite[] hairlayer;
    int currentBody, currentHair;
    string sex = "male";
    Image representation;


    void Start() {
        representation = GameObject.Find("representation").GetComponent<Image>();
        currentBody = 0;
        currentHair = 0;
        bodylayer = Resources.LoadAll<Sprite>("Universal_Sprites/body/" + sex);

    }

    // Update is called once per frame
    void Update() {

    }
    public void ChangeSex()
    {
        if(sex == "male")
        {
            sex = "female";
        }
        else
        {
            sex = "male";
        }
    }
}

