using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

public class Spotlight : MonoBehaviour
{
    [FormerlySerializedAs("thePlayer")] public GameObject targetGameObject;

    public Vector3 collision = Vector3.zero;

    [SerializeField] private string selectableTag = "Player";

    private int Thickness;


    private float _raythickness = 2f;
    private bool targeted;

    private void Update()
    {
        transform.LookAt(targetGameObject.transform);
        
        
        if (!targeted)
        {
            var transform1 = transform;
            Ray landingRay = new Ray(transform1.position, transform1.forward);
            
            RaycastHit[] hits = Physics.SphereCastAll(landingRay, _raythickness, float.PositiveInfinity);

            for (var i = 0; i < hits.Length; i++)
            {
                if (hits[i].collider.CompareTag("Player"))
                {
                    RaycastHit hit;

                    Vector3 dir = (transform.position - hits[i].transform.position).normalized;

                    Ray raycastRay = new Ray(transform.position, dir);
                    
                    if (Physics.Raycast(raycastRay, out hit, float.PositiveInfinity))
                    {
                        if (hit.collider.tag == "Player")
                        {
                            DetectedPlayer();
                        }
                    }
                    DetectedPlayer();
                    
                    break;
                }
            }
            
            
            // if (Physics.SphereCast(landingRay, _raythickness, out hit, float.PositiveInfinity))
            // {
            //     Debug.DrawLine(landingRay.origin, hit.point, Color.yellow, 1f);
            //
            //     if (hit.collider.tag == "Player")
            //     {
            //         DetectedPlayer();
            //     }
            // }

            // if (Physics.Raycast(landingRay, out hit, float.PositiveInfinity))
            // {
            //     Debug.DrawLine(landingRay.origin, hit.point, Color.magenta, 1f);
            //     
            //     if (hit.collider.tag == "Player")
            //     {
            //         DetectedPlayer();
            //     }
            // } STRG K C / STRG K U
        }
    }
    
    
    private void DetectedPlayer()
    {
        Debug.Log("!!! U GOT DETECTED !!!");
    }
    
    
    /*private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(colission, 1.5f);
    }*/
}
