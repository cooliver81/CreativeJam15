using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar : MonoBehaviour
{
    public Transform bar;
    public Transform chargeBar = null;
    public float valueBar = 1f;
    public float valueCharge = 0f;

    public float maxValue = 1f;
    public float minValue = 0f;

    // Start is called before the first frame update
    private void Start()
    {
        valueBar = maxValue;

        if(bar != null){
            bar.localScale = new Vector3(valueBar, 1f);
            chargeBar = gameObject.transform.Find("charge");

            if(chargeBar != null){
                valueCharge = valueBar;
                chargeBar.localScale = new Vector3(valueCharge, 1f);
            }
        }

    }

    public void setValue(float value)
    {
        bar.localScale = new Vector3(value, 1f);
    }

    public void setChargeValue(float value)
    {
        chargeBar.localScale = new Vector3(value, 1f);
    }

    // Update is called once per frame
    private void Update()
    {
        // Update value
        bar.localScale = new Vector3(valueBar, 1f);
        if (chargeBar != null){
            chargeBar.localScale = new Vector3(valueCharge, 1f);
        }


        // Set max and min
        if(valueBar < minValue){
            valueBar = minValue;
        }
        if(valueBar > maxValue){
            valueBar = maxValue;
        }

       if(valueCharge < minValue){
            valueCharge = minValue;
       }
       if(valueCharge > maxValue)
       {
            valueCharge = maxValue;
       }

    }
}
