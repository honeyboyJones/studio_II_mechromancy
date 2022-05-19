using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BelayStateManager : MonoBehaviour
{
    [HideInInspector]
    public bool isSaved = false;
    [HideInInspector]
    public Beacon beacon;
    [HideInInspector]
    public ParticleManager particleManager;
    public float maxSaveDistance = 2.5f;
    [HideInInspector]
    public TitanfallMovement player;
    public int BeaconAmount = 100;
    //public Vector3 standByPos;
    //public Vector3 standByNormal;
    

    BelayStateBase currentState;
    BelayStateDeafault belayStateDeafault = new BelayStateDeafault();
    BelayStateStandby belayStateStandby = new BelayStateStandby();
    BelayStateSave belayStateSave = new BelayStateSave();
    
    void Start()
    {
        player = FindObjectOfType<TitanfallMovement>();
        beacon = FindObjectOfType<Beacon>();
        currentState = belayStateDeafault;
        currentState.EnterState(this);
        particleManager = FindObjectOfType<ParticleManager>();
        
    }

    
    void Update()
    {
        //Debug.Log(currentState);
        currentState.UpdateState(this);
        isSaved = beacon.isSaved;
        Debug.Log(isSaved);
        //standByPos = particleManager.collisionPosition;
        //standByNormal = particleManager.collisionNormal;
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
