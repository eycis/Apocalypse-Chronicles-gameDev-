using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BarrierController : MonoBehaviour
{
    public GameObject barrier;

    public int requiredMushrooms = 15;
    public int requiredStones = 15;

    private FPSController fpsController;

    //private bool isGameOver = false;

    void Start()
    {
        barrier.SetActive(true);
        if(barrier.activeSelf)
        {
            
            Debug.Log("bariéra by měla být active");
        }
        fpsController = FindObjectOfType<FPSController>();
        if(fpsController != null)
        {
            Debug.Log("fps se našel");
        }
    }

    void Update()
    {
        if (fpsController.numberOfMushrooms >= requiredMushrooms && fpsController.numberOfStones >= requiredStones)
        {
            Debug.Log("máš dost všeho");
            barrier.SetActive(false);
        }
        else
        {
            barrier.SetActive(true);
        }
    }
}