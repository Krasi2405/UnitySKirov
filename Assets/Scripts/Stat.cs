using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stat : MonoBehaviour {

    [SerializeField]private float lerpSpeed = 1;
    [SerializeField]private Text statText;

    private float maxAmount;
    private float currentAmount;
    private Image image;
    private float currentFill = 1;


    void Start () {
        image = GetComponent<Image>();
        currentAmount = maxAmount;
    }

    public void InitStat(float current, float max)
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
        statText.text = currentAmount + " / " + maxAmount;
    }

    private void Update()
    {   
        if(currentFill != image.fillAmount)
        {
            image.fillAmount = Mathf.Lerp(image.fillAmount, currentFill, lerpSpeed);
            
        }
        image.fillAmount = currentFill;
    }

}
