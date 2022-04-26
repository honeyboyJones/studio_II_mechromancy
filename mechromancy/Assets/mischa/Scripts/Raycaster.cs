using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycaster : MonoBehaviour
{
    [SerializeField]
    LayerMask layerMask; //target specific layer

    RaycastHit hitInfo; //store hit info

    public float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Ray ray = new Ray(transform.position + new Vector3(0, 2, 0), transform.TransformDirection(Vector3.down)); //transform = origin (crab), transformDirection = orientation

        if(Physics.Raycast(ray, out RaycastHit hitInfo, 50f, layerMask)) //set raycast, if shooting ray; 50f = ray travel distance
        {
            Debug.Log("hit something"); //show if hit
            Debug.DrawRay(transform.position + new Vector3(0, 2, 0), transform.TransformDirection(Vector3.down) * hitInfo.distance, Color.red); //draw ray between object and target, object-target distance

            Vector3 surfaceNormal = hitInfo.normal; //target normal when hit
            Vector3 newDir = Vector3.RotateTowards(transform.up, surfaceNormal, rotationSpeed * Time.deltaTime, 0f); //set new direction; rotate y towards surfaceNormal @ rotation speed with 0 magnitude change/change to vector size

            //transform.rotation = Quaternion.FromToRotation(transform.up, newDir); //set rotation in relation new dir, align y-axis to new dir

            //transform.rotation = Quaternion.FromToRotation(transform.up, surfaceNormal); //set rotation in relation to normal in upwards direction
            Quaternion targetRotation = Quaternion.FromToRotation(transform.up, surfaceNormal); //get target rotation
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime); //assign rotate function return value, rotate from current to target position @ set speed ≠ snap

            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, 0, transform.localEulerAngles.z); //hard reset y axis, clamp to 0; ensure obj is pointing to right position/direciton
        }
    }
}
