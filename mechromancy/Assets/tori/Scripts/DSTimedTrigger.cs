using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DSTimedTrigger : MonoBehaviour
{
    public float timer = 3; //time to wait for invoking dialogue, set in inspector
    public GameObject dialogueObject; //set in inspector, the dialogue object being enabled and disabled.
                                      //This object's Dialogue Trigger Component will start an action upon being enabled. 

    // Start is called before the first frame update
    void Start()
    {
        Invoke("EnableDialogueObject", timer); //after ? seconds, call EnableDialogueObject function
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void EnableDialogueObject()
    {
        dialogueObject.SetActive(true); //set dialogueObject to active, enabling the attached dialogue trigger.
    }
}
