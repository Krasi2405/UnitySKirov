using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBar : MonoBehaviour {

    [SerializeField]
    private float maxAmount;
    [SerializeField]
    private float currentAmount;

    [SerializeField] private Image image;

	void Start () {
        /*
        image.type = Image.Type.Filled;
        image.fillMethod = Image.FillMethod.Horizontal;
        image.fillOrigin = 0;
        */ // TODO: Da go napravq da raboti :)
    }

    
    public void SetMaxAmount(float amount)
    {
        maxAmount = amount;
    } 

    
    public void SetCurrentAmount(float amount)
    {
        currentAmount = amount;
    }


    public void ChangeUIBar()
    {
        image.fillAmount = currentAmount / maxAmount;
        Debug.Log("change uibar to " + currentAmount / maxAmount);
    }
}
