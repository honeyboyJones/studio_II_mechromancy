using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycaster : MonoBehaviour
{
    [SerializeField]
    LayerMask layerMask; //target specific layer

    RaycastHit hitInfo; //store hit info

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Ray ray = new Ray(transform.position, transform.TransformDirection(Vector3.down)); //transform = origin (crab), transformDirection = orientation

        if(Physics.Raycast(ray, out RaycastHit hitInfo, 50f, layerMask)) //set raycast, if shooting ray; 50f = ray travel distance
        {
            Debug.Log("hit something"); //show if hit
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hitInfo.distance, Color.red); //draw ray between object and target, object-target distance

            Vector3 surfaceNormal = hitInfo.normal; //target normal when hit
            transform.rotation = Quaternion.FromToRotation(transform.up, surfaceNormal); //set rotation in relation to normal in upwards direction
        }
    }
}
