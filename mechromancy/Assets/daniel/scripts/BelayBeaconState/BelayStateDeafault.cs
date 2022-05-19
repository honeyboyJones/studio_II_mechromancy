using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BelayStateDeafault : BelayStateBase
{
    //this is the deafault state for belay beacon, calculate "F key" in update
    public override void EnterState(BelayStateManager stateManager) 
    {
        //Debug.Log("enter deafault");
    }
    public override void UpdateState(BelayStateManager stateManager) 
    {
        if (Input.GetKeyDown(KeyCode.F)) 
            
        {
            if (stateManager.isSaved) 
                //load if it's saved
            {
                EventManager.TriggerEvent("load");
                //if its saved, then load and stay in default state
            }

            //if not saved, go standby ad ready to save
            if (stateManager.isSaved == false) 
            {
                if (stateManager.BeaconAmount > 0)
                {
                    stateManager.BelayStandby();
                }
                else 
                {
                    EventManager.TriggerEvent("savefailed");
                }
                
            }
            
        }

        if (Input.GetKeyDown(KeyCode.R)) 
        {
            Debug.Log(stateManager.isSaved);
            if (stateManager.isSaved == true)
            {
                EventManager.TriggerEvent("cancle");
            }
            else 
            {
                EventManager.TriggerEvent("savefailed");
            }
                
        }
    }
    public override void ExitState(BelayStateManager stateManager) 
    {

    }
}
