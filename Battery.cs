using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Light))]
public class Battery : MonoBehaviour
{
    public GameObject flashlight;

    private Light flashlightLight;
    // Start is called before the first frame update
    void Start()
    {
        flashlightLight = flashlight.GetComponent<Light>();
        flashlightLight.enabled = false; //při spuštění hry vypnuté
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            ToggleFlashLight();
        }
    }

    private void ToggleFlashLight()
    {
        flashlightLight.enabled = !flashlightLight.enabled;
    }
}
