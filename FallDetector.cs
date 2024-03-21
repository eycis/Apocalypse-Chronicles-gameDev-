using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FallDetector : MonoBehaviour
{

    private GameManager gameManager;

    public GameObject Lake;
    private FPSController fpsController;


    // Start is called before the first frame update
    void Start()
    {
         gameManager = FindObjectOfType<GameManager>();
         Debug.Log("fall detector našel game manager");
         fpsController = FindObjectOfType<FPSController>();
    }

    // Update is called once per frame
    void Update()
    {   
        
    }
        void OnTriggerEnter(Collider other)
        {
            Debug.Log("Volá se metoda ontrigger enter");
            if (other.CompareTag("Player"))
            {
                Debug.Log("hráč je v cube");
                gameManager.RestartGame();
            }
    }
}