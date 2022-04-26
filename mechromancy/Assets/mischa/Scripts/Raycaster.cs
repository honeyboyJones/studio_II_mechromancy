using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycaster : MonoBehaviour
{
    [SerializeField]
    LayerMask layerMask; //target specific layer

    RaycastHit hitInfo; //store hit info

    public float rotationSpeed;

    Quaternion savedRotation; //non-inverted rotation, default value for calculations

    // Start is called before the first frame update
    void Start()
    {
        savedRotation = transform.rotation; //set default rotation
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Ray ray = new Ray(transform.position + new Vector3(0, 2, 0), transform.TransformDirection(Vector3.down)); //transform = origin (crab), transformDirection = orientation

        if(Physics.Raycast(ray, out RaycastHit hitInfo, 50f, layerMask)) //set raycast, if shooting ray; 50f = ray travel distance; always happening, when on ground
        {
            Debug.Log("hit something"); //show if hit
            Debug.DrawRay(transform.position + new Vector3(0, 2, 0), transform.TransformDirection(Vector3.down) * hitInfo.distance, Color.red); //draw ray between object and target, object-target distance

            Vector3 surfaceNormal = hitInfo.normal; //target normal when hit
            Vector3 newDir = Vector3.RotateTowards(transform.up, surfaceNormal, rotationSpeed * Time.deltaTime, 0f); //set new direction; rotate y towards surfaceNormal @ rotation speed with 0 magnitude change/change to vector size

            //transform.rotation = Quaternion.FromToRotation(transform.up, newDir); //set rotation in relation new dir, align y-axis to new dir

            //transform.rotation = Quaternion.FromToRotation(transform.up, surfaceNormal); //set rotation in relation to normal in upwards direction
            //Quaternion targetRotation = Quaternion.FromToRotation(transform.up, surfaceNormal); //get target rotation (local upwards)
            Quaternion targetRotation = Quaternion.FromToRotation(Vector3.up, surfaceNormal); //get target rotation; vector3 = world upwards

            //transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime); //assign rotate function return value, rotate from current to target position @ set speed ≠ snap (world rotation)
            //transform.localRotation = Quaternion.RotateTowards(transform.localRotation, targetRotation, rotationSpeed * Time.deltaTime); //change local rotation
            savedRotation = Quaternion.RotateTowards(savedRotation, targetRotation, rotationSpeed * Time.deltaTime); //assign rotate function return value, rotate from current to target position @ set speed ≠ snap (saved rotation)


            Vector3 tempEulerAngle = savedRotation.eulerAngles; //convert rotation to use Euler angles


            //transform.rotation = savedRotation; //assign transform as new default, invert default
            //transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, 0, transform.localEulerAngles.z); //hard reset y axis, clamp to 0; ensure obj is pointing to right position/direction
            tempEulerAngle = new Vector3(tempEulerAngle.x, 0, tempEulerAngle.z); //hard reset y axis, clamp to 0; ensure obj is pointing to right position/direction; convert to use Euler angles

            float dotProduct = Vector3.Dot(transform.parent.forward, surfaceNormal); //compute dotProduct between parent forward position and surface normal

            if(dotProduct < 0) //if negative, walking uphill
            {
                tempEulerAngle = new Vector3(Mathf.Abs(tempEulerAngle.x) * -1, 0, tempEulerAngle.z); //hard reset y axis, clamp to 0; ensure obj is pointing to right position/direction; invert x, set to (-); convert to use Euler angles
            }
        }

        //Transform child = transform.GetChild(0); //crab (1)
        //transform.localPosition += child.localPosition; //parent position + child movement = new parent position
        //child.localPosition = Vector3.zero; //reset child local position to 0
    }
}
