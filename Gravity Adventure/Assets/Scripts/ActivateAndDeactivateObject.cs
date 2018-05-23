using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateAndDeactivateObject : MonoBehaviour { //Activates/Deactivates the target GameObject upon using of the OpenAndCloseMenu Method (for easy UI Management)

    public GameObject TargetObject;

    public void ActivateAndDeactivate()
    {
        if(TargetObject.activeSelf)
        {
            TargetObject.SetActive(false);
        } else
        {
            TargetObject.SetActive(true);
        }
    }
}