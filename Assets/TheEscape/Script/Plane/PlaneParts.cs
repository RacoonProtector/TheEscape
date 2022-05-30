using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneParts : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject cockpit;
    [SerializeField] private GameObject upperWing;
    [SerializeField] private GameObject lowerWing;
    [SerializeField] private GameObject propeller;
    [SerializeField] private GameObject tail;
    
    [SerializeField] private GameObject co_cockpit;
    [SerializeField] private GameObject co_upperWing;
    [SerializeField] private GameObject co_lowerWing;
    [SerializeField] private GameObject co_propeller;
    [SerializeField] private GameObject co_tail;


    private float planeScore;

    public void Interact()
    {
        ActivatePlaneParts();
    }

    public void ActivatePlaneParts()
    {
        if (gameObject.name == "M_Co_Cockpit")
        {
            cockpit.gameObject.SetActive(true); 
            co_cockpit.gameObject.SetActive(false);

            planeScore += 1;
        }
        
        if (gameObject.name == "M_Co_Tail")
        {
            tail.gameObject.SetActive(true); 
            co_tail.gameObject.SetActive(false);
            
            planeScore += 1;
        }
        
        if (gameObject.name == "M_Co_UpperWing")
        {
            upperWing.gameObject.SetActive(true); 
            co_upperWing.gameObject.SetActive(false);
            
            planeScore += 1;
        }
        
        if (gameObject.name == "M_Co_Tires")
        {
            lowerWing.gameObject.SetActive(true); 
            co_lowerWing.gameObject.SetActive(false);
            
            planeScore += 1;
        }
        
        if (gameObject.name == "M_Co_Propeller")
        {
            propeller.gameObject.SetActive(true); 
            co_propeller.gameObject.SetActive(false);
            
            planeScore += 1;
        }
        
    }

    public void PlaneEndScore()
    {
        if (planeScore > 4)
        {
            //EndFunction
            Debug.Log("U DID IT");
        }
    }
    
    public void disconnectInteraction()
    {
        
    }
    
    
}
