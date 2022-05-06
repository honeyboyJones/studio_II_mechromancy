using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchEventTrigger : MonoBehaviour
{
    private bool isday = true;
    // Start is called before the first frame update
    void Start()
    {
        EventManager.TriggerEvent("SwitchToDay");//game scene is day time by default
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) 
        {
            if (isday)
            {
                EventManager.TriggerEvent("SwitchToNight");
                isday = false;
            }
            else 
            {
                EventManager.TriggerEvent("SwitchToDay");
                isday = true;
            }
            
            
        }

       
    }
}
