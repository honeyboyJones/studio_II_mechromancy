using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BelayStateBase 
{
    public abstract void EnterState(BelayStateManager stateManager);
    public abstract void UpdateState(BelayStateManager stateManager);
    public abstract void ExitState(BelayStateManager stateManager);
}
