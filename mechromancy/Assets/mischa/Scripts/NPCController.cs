using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Code;

public class NPCController : MonoBehaviour
{
    NPCConnectedPatrol npcConnectedPatrol;

    // Start is called before the first frame update
    void Start()
    {
        npcConnectedPatrol = GetComponent<NPCConnectedPatrol>();
    }
}