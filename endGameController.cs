using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class endGameController : MonoBehaviour
{
    public Text endGameText;
    // Start is called before the first frame update
    void Start()
    {
        endGameText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //endGameText.SetActive(true);
            string textToShow = endGameText.text;
            endGameText.enabled = true;
        }
    }
}
