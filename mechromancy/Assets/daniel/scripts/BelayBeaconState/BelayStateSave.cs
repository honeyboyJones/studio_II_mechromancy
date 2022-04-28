using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BelayStateSave: BelayStateBase
{
    //this is the save state of belay beacon
    //save position when enter this state, then transit to deafault directly
    public override void EnterState(BelayStateManager stateManager)
    {
        EventManager.TriggerEvent("Save");
        stateManager.BelayDefault();
    }
    public override void UpdateState(BelayStateManager stateManager)
    {

    }
    public override void ExitState(BelayStateManager stateManager)
    {

    }
}
