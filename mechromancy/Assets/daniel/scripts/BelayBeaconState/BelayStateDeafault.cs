using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BelayStateDeafault : BelayStateBase
{
    //this is the deafault state for belay beacon, calculate "F key" in update
    public override void EnterState(BelayStateManager stateManager) 
    {
        
    }
    public override void UpdateState(BelayStateManager stateManager) 
    {
        if (Input.GetKeyDown(KeyCode.F)) 
        {
            if (stateManager.isSaved) 
                //load if it's saved
            {
                EventManager.TriggerEvent("Load");
            }

            //if not saved, go standby ad ready to save
            stateManager.BelayStandby();
        }
    }
    public override void ExitState(BelayStateManager stateManager) 
    {

    }
}
