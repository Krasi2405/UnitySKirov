using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthbar : UIBar {


    DamageController hitController;

    // TODO: call everything from HitController!;

    private void Start()
    {
        hitController = FindObjectOfType<DamageController>();
        SetMaxAmount(hitController.maxHp);
    }

    private void Update()
    {
        SetCurrentAmount(hitController.hp);
        ChangeUIBar();
    }
}
