using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BelayStateStandby : BelayStateBase
{
    //this is the standby state for belay beacon, calculating the trail in update
    //transit to save state when F key released.
    public override void EnterState(BelayStateManager stateManager)
    {
        //Debug.Log("enter standby state");
        //stateManager.particleManager.ParticleBegin();
        stateManager.beacon.meshRenderer.enabled = true;
        EventManager.TriggerEvent("prepare");
    }
    public override void UpdateState(BelayStateManager stateManager)
    {
        ModelStandBy(stateManager);

        if (isReachable(stateManager))
        {
            stateManager.particleManager.particle.startColor = new Color(0, 1, 0, 1);
            stateManager.beacon.meshRenderer.material.SetColor("_Albedo", new Color(0, 1, 0, 1));
            stateManager.beacon.meshRenderer.material.SetFloat("_Transparency", 0.3f);
            if (Input.GetKeyUp(KeyCode.F))
            {
                stateManager.BelayStateSave();
            }
        }
        else 
        {
            stateManager.particleManager.particle.startColor = new Color(1, 0, 0, 1);
            stateManager.beacon.meshRenderer.material.SetColor ("_Albedo", new Color(1, 0, 0, 1));
            stateManager.beacon.meshRenderer.material.SetFloat("_Transparency", 0.3f);
            if (Input.GetKeyUp(KeyCode.F))
            {
                stateManager.BelayDefault();
                stateManager.beacon.gameObject.GetComponent<Transform>().position = stateManager.beacon.savePosition;
                stateManager.beacon.meshRenderer.enabled = false;
                EventManager.TriggerEvent("savefailed");
            }
        }

        
    }
    public override void ExitState(BelayStateManager stateManager)
    {
        stateManager.particleManager.ParticlePause();
    }
    public void ModelStandBy(BelayStateManager manager) 
    {
        
        //relocate the belay beacon model
        manager.beacon.gameObject.GetComponent<Transform>().position = manager.particleManager.collisionPosition;

        //rotate the belay beacon model
        //Vector3 DeltaRotation = manager.particleManager.collisionNormal - manager.beacon.gameObject.GetComponent<Transform>().up;
        //manager.beacon.gameObject.GetComponent<Transform>().Rotate(DeltaRotation);
        manager.beacon.gameObject.GetComponent<Transform>().rotation = Quaternion.Euler(manager.particleManager.collisionNormal);
    }

    //to calculate if the distance is near enough to save
    public bool isReachable(BelayStateManager manager) 
    {
       // Debug.Log((manager.particleManager.collisionPosition
            //- manager.player.gameObject.GetComponent<Transform>().position).magnitude);
        if ((manager.particleManager.collisionPosition
            - manager.player.gameObject.GetComponent<Transform>().position).magnitude < manager.maxSaveDistance)
        {
            return true;
        }
        else 
        {
            return false;
        }
    }
}
