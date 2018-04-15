using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthbar : UIBar {


    HitController hitController;

    // TODO: call everything from HitController!;

    private void Start()
    {
        hitController = FindObjectOfType<HitController>();
        SetMaxAmount(hitController.hp);
    }

    private void Update()
    {
        SetCurrentAmount(hitController.hp);
        ChangeUIBar();
    }
}
