using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stat : MonoBehaviour {

    private float maxAmount;
    [SerializeField]private float lerpSpeed = 1;

    private float currentAmount;
    private Image image;
    private float currentFill = 1;

	void Start () {
        image = GetComponent<Image>();

    }

    public void InitStat(int current, int max)
    {
        currentAmount = current;
        maxAmount = max;
    }
    
    public void SetMaxAmount(float amount)
    {
        maxAmount = amount;
    } 

    
    public void SetCurrentAmount(float amount)
    {
        if (currentAmount < maxAmount)
        {
            currentAmount = amount;
        }
        else if(currentAmount < 0)
        {
            currentAmount = 0;
        }
        else {
            currentAmount = maxAmount;
        }
        currentFill = currentAmount / maxAmount;
    }

    private void Update()
    {   
        if(currentFill != image.fillAmount)
        {
            image.fillAmount = Mathf.Lerp(image.fillAmount, currentFill, lerpSpeed);
            Debug.Log(image.fillAmount);
        }
        image.fillAmount = currentAmount / maxAmount;
    }

}
