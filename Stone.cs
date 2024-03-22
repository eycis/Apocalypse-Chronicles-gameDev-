using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(BoxCollider))]
public class Stone : MonoBehaviour
{
    private bool hasInteracted = false;

    private int pointsToAdd = 1;
    private FPSController fpsController;

    private float InteractRange = 5f;

    private UIControllerStones uiController;


    // Start is called before the first frame update
    void Start()
    {
        fpsController = FindObjectOfType<FPSController>();

        uiController = FindObjectOfType<UIControllerStones>();

    }
    
    public void Interact()
    {
        if(hasInteracted)
        {
            return;
        }

        float distanceToPlayer = Vector3.Distance(transform.position, fpsController.transform.position);
        if(distanceToPlayer <= InteractRange)
        {
            fpsController.CollectStones(pointsToAdd);
            hasInteracted = true;
            Destroy(gameObject);
        }  
    }
    // Update is called once per frame
    void Update()
    {

        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                Stone stone = hit.collider.GetComponent<Stone>();
                if(stone != null)
                {
                    stone.Interact();
                }
                }
            }
        }
        
    }
