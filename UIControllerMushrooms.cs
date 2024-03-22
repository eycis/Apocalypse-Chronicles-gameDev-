using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControllerMushrooms : MonoBehaviour
{
    public Text mushroomCountText;
    

    private int mushroomCount = 0;

    
    // Start is called before the first frame update
    void Start()
    {
        mushroomCountText.text = "Mushrooms: " +mushroomCount+ "/15";
    }

    // Update is called once per frame
    void Update()
    {
    }
    
    public void UpdateMushroomCount(int newCount)
    {
        mushroomCount = newCount;
        mushroomCountText.text = "Mushrooms: " +mushroomCount +"/15";
    }
}
