using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BelayStateStandby : BelayStateBase
{
    //this is the standby state for belay beacon, calculating the trail in update
    //transit to save state when F key released.
    public override void EnterState(BelayStateManager stateManager)
    {

    }
    public override void UpdateState(BelayStateManager stateManager)
    {
        //render the trial and landing point.
        if (Input.GetKeyUp(KeyCode.F)) 
        {
            stateManager.BelayStateSave();
        }
    }
    public override void ExitState(BelayStateManager stateManager)
    {

    }
}
