using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stat : MonoBehaviour {

    private int maxAmount = 100;
    [SerializeField]private float lerpSpeed = 1;

    private int currentAmount;
    private Image image;
    private float currentFill = 1;

	void Start () {
        image = GetComponent<Image>();
        currentAmount = maxAmount;
    }

    public void InitStat(int current, int max)
    {
        currentAmount = current;
        maxAmount = max;
    }
    
    public void SetMaxAmount(int amount)
    {
        maxAmount = amount;
    } 

    
    public void SetCurrentAmount(int amount)
    {
        Debug.Log("Called");
        if (amount > maxAmount)
        {
            currentAmount = maxAmount;
        }
        else if(amount < 0)
        {
            currentAmount = 0;
        }
        else {
            currentAmount = amount;
        }
        currentFill = currentAmount / maxAmount;
    }

    private void Update()
    {   
        if(currentFill != image.fillAmount)
        {
            image.fillAmount = Mathf.Lerp(image.fillAmount, currentFill, lerpSpeed);
            
        }
        Debug.Log(image.fillAmount);
        image.fillAmount = currentFill;
    }

}
