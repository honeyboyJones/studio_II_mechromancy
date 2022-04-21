using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nate : MonoBehaviour
{
    public Transform startPoint;
    public GameObject player = GameObject.Find("zTTFPlayer");
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            player.transform.position = startPoint.position;
        }
    }
}
