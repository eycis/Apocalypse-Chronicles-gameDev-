using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControllerStones : MonoBehaviour
{
    public Text stoneCountText;
    private int stoneCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        stoneCountText.text = "Crystals: " +stoneCount +"/15";
    }

    // Update is called once per frame
    void Update()
    {
        //stoneCountText.text = "Stones: " +stoneCount;
    }
    public void UpdateStoneCount(int newCount)
    {
        stoneCount = newCount;
        Debug.Log("update stonecount from controller" + stoneCount);
        stoneCountText.text = "Crystals: " +stoneCount+ "/15";
    }
}
