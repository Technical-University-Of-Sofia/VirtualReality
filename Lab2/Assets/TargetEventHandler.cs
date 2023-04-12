using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Vuforia;

public class TargetEventHandler : DefaultObserverEventHandler
{
    public UnityEvent OnFound; //allow adding event handlers in Unity Editor

    protected override void OnTrackingFound()
    {
        base.OnTrackingFound(); //insure default behaviour from parent is executed
        
        if(OnFound != null) //check for registered event handlers
        {
            OnFound.Invoke();
        }
    }
}