using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BelayStateManager : MonoBehaviour
{
    public bool isSaved = false;
    public bool isReachable = false;
    public Beacon beacon;
    

    BelayStateBase currentState;
    BelayStateDeafault belayStateDeafault = new BelayStateDeafault();
    BelayStateStandby belayStateStandby = new BelayStateStandby();
    BelayStateSave belayStateSave = new BelayStateSave();
    
    void Start()
    {
        currentState = belayStateDeafault;
        currentState.EnterState(this);
        
    }

    
    void Update()
    {
        currentState.UpdateState(this);
        isSaved = beacon.isSaved;
    }

    public void TransitState(BelayStateBase nextState) 
    {
        currentState.ExitState(this);
        nextState.EnterState(this);
        currentState = nextState;
        
    }

    public void BelayDefault() 
    {
        TransitState(belayStateDeafault);
    }

    public void BelayStandby() 
    {
        TransitState(belayStateStandby);
    }

    public void BelayStateSave() 
    {
        TransitState(belayStateSave);
    }
}
