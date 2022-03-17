using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zinnia.Action;

public class PointerActivate : MonoBehaviour
{
    public BooleanAction ActivationAction;
 
    void Update()
    {
        ActivationAction.DefaultValue = true;
        ActivationAction.DefaultValue = false;
    }
}
