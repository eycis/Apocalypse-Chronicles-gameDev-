using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public Image ImgHealtBar;

    public Text TxtHealth;

    public int Min;

    public int max;
    
    private int mCurrentValue;

    private float mCurrentPercent;

    public void SetHealth(int health)
    {
        if(health != mCurrentValue)
        {
            if(max - Min == 0)
            {
                mCurrentPercent = 0;
                mCurrentValue = 0;
            }
            else
            {
                mCurrentValue = health;
                mCurrentPercent = Mathf.Clamp01((float) mCurrentValue / (float) (max - Min));
            }
            // if(mCurrentValue <= 0)
            // {
                
            // }

            TxtHealth.text = string.Format("{0} %", Mathf.RoundToInt(mCurrentPercent *100));
            ImgHealtBar.fillAmount = mCurrentPercent;
        }
    }

    public float CurrentPercent
    {
        get 
        {
            return mCurrentPercent;
        }
    }
    public int CurrentValue
    {
        get
        {
            return mCurrentValue;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        SetHealth(100);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
