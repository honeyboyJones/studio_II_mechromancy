using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem; 

public class ScannedVariables : MonoBehaviour
{
    int mews = DialogueLua.GetVariable("Mews Scanned").asInt;
    int plexii = DialogueLua.GetVariable("Plexii Scanned").asInt;
    int crobos = DialogueLua.GetVariable("Crobos Scanned").asInt;
    int simums = DialogueLua.GetVariable("Simums Scanned").asInt; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (mews == 3) //if 3 Mews have been scanned....
        {
            DisableTag(); //...call DisableTag Function.
        }
    }

    void DisableTag()
    {
        GameObject[] gameObjectArray = GameObject.FindGameObjectsWithTag("Scannable"); //establish gameObject Array

        foreach (GameObject go in gameObjectArray) 
        {
            go.SetActive(false); //Disable each object tagged Scannable
        }
    }
}
