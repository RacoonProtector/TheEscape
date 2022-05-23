using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spotlight : MonoBehaviour
{
    public GameObject thePlayer;

    private void Update()
    {
        transform.LookAt(thePlayer.transform);
    }
}
