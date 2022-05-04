using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class ScannedVariables : MonoBehaviour
{
    public int scanNum = 1; //1 for testing, 3 IRL

    public float mewsScanned = 0f; //mew scanned variable, not sure if it needs to be public.
    public float plexiiScanned = 0f;
    public float croboScanned = 0f;
    public float simumScanned = 0f;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if (mewsScanned == scanNum) //if 3 Mews have been scanned, disable Plexii tagged objects
        {
            DisableMewTag(); 
        }

        if (plexiiScanned == scanNum) //if 3 Plexii have been scanned, disable Plexii tagged objects
        {
            DisablePlexiiTag();
        }

        if (croboScanned == scanNum) //if 3 Crobos have been scanned, disable Plexii tagged objects
        {
            DisableCroboTag();
        }

        if (simumScanned == scanNum) //if 3 Simums have been scanned, disable Plexii tagged objects
        {
            DisableSimumTag();
        }
    }

    public void ChangeMewScanAmount() //add 1 to mew scanned amount
    {
        mewsScanned++; 
    }

    public void ChangePlexiiScanAmount() //add 1 to plexii scanned amount
    {
        plexiiScanned++; 
    }

    public void ChangeCroboScanAmount() //add 1 to crobo scanned amount
    {
        croboScanned++; 
    }

    public void ChangeSimumScanAmount() //add 1 to simum scanned amount
    {
        simumScanned++; 
    }

    void DisableMewTag() //Disable each object tagged Mew
    {
        GameObject[] mewTag = GameObject.FindGameObjectsWithTag("Mews"); //establish gameObject Array

        foreach (GameObject go in mewTag)
        {
            go.SetActive(false);
        }
    }

    void DisablePlexiiTag() //Disable each object tagged Plexii
    {
        GameObject[] plexiiTag = GameObject.FindGameObjectsWithTag("Plexii"); //establish gameObject Array

        foreach (GameObject go in plexiiTag)
        {
            go.SetActive(false); 
        }
    }

    void DisableCroboTag() //Disable each object tagged Crobo
    {
        GameObject[] croboTag = GameObject.FindGameObjectsWithTag("Crobo"); //establish gameObject Array

        foreach (GameObject go in croboTag)
        {
            go.SetActive(false); 
        }
    }

    void DisableSimumTag() //Disable each object tagged Simum
    {
        GameObject[] simumTag = GameObject.FindGameObjectsWithTag("Simum"); //establish gameObject Array

        foreach (GameObject go in simumTag)
        {
            go.SetActive(false); 
        }
    }
}
