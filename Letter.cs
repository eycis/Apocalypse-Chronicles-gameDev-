using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Letter : MonoBehaviour
{
    
    public Text textComponent;

    public float InteractRange = 2;
    
    private bool isTextShown = false;
    // Start is called before the first frame update
    void Start()
    {
        textComponent.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    Debug.Log("Klikáš");
                    if (!isTextShown)
                    {
                        ShowText();
                    }
                    else
                    {
                        HideText();
                    }
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            HideText();
        }
}
    void ShowText()
    {
        string textToShow = textComponent.text;
        textComponent.enabled = true;
        isTextShown = true;
    }

    // Funkce pro skrytí textu
    void HideText()
    {
        textComponent.enabled = false;
        isTextShown = false;
    }
}