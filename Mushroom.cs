using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(BoxCollider))]
public class Mushroom : MonoBehaviour
{
    private bool hasInteracted = false;

    public int pointsToAdd = 1;
    private FPSController fpsController;

    private float InteractRange = 5f;
    
    private UIControllerMushrooms uiController;

    public void Interact()
    {
        if(hasInteracted)
        {
            return;
        }
        float distanceToPlayer = Vector3.Distance(transform.position, fpsController.transform.position);

        if(fpsController != null)
        {
            fpsController = FindObjectOfType<FPSController>();
            if(distanceToPlayer <= InteractRange)
            {
                fpsController.CollectMushrooms(pointsToAdd);
                hasInteracted = true;
                Destroy(gameObject);
            }
   
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        fpsController = FindObjectOfType<FPSController>();
        uiController = FindObjectOfType<UIControllerMushrooms>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out RaycastHit hit))
            {
                Mushroom mushroom = hit.collider.GetComponent<Mushroom>();
                if(mushroom != null)
                {
                    mushroom.Interact();
                }
            }
        }
    }
}
