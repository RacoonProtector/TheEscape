using System;
using System.Collections;
using System.Collections.Generic;
using TheEscape.Script;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    private Camera _camera;

    private Note _note;
    
    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            print("Hey hey");

            SearchForInteractable();
        }
        
        else if(Input.GetKeyDown(KeyCode.Q))
        {
            SearchForInteractableAndDeactivate();
        }
    }
    
    private void SearchForInteractable()
    {
        var nearestGameObject = GetNearestGameObject();
        if (nearestGameObject == null)
        {
            return;
        }

        var interactable = nearestGameObject.GetComponent<IInteractable>();
        if (interactable == null)
        {
            return;
        }

        interactable.Interact();
        
        //Time.timeScale = 0;
    }
    
    private void SearchForInteractableAndDeactivate()
    {
        var nearestGameObject = GetNearestGameObject();
        if (nearestGameObject == null)
        {
            return;
        }

        var interactable = nearestGameObject.GetComponent<IInteractable>();
        if (interactable == null)
        {
            return;
        }

        interactable.disconnectInteraction();
        
        //Time.timeScale = 1;
    }

    private GameObject GetNearestGameObject()
    {
        GameObject result = null;
        var ray = _camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out var hit, 3))
        {
            result = hit.transform.gameObject;
            Debug.DrawLine(ray.origin, hit.point, Color.magenta, 1f);
        }
        return result;
    }
    
    
}