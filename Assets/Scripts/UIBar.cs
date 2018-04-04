using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBar : MonoBehaviour {

    [SerializeField]
    private float maxAmount;

    [SerializeField]
    private float currentAmount;

    private Image image;

	void Start () {
        image = GetComponent<Image>();
        image.type = Image.Type.Filled;
        image.fillMethod = Image.FillMethod.Horizontal;
        image.fillOrigin = 0;
    }


	void Update () {
        ChangeUIBar();
	}
    

    public void ChangeUIBar()
    {
        image.fillAmount = currentAmount / maxAmount;
    }
}
