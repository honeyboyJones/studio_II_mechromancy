using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    public float mouseSensitivity = 100f; //for tuning sensitivity
    public Transform playerBody; //reference the player object

    float xRotation = 0f; //used for the camera tilt


    //called before the first frame update
    void Start()
    {
        //hides and locks the cursor to the center of the screen
        Cursor.lockState = CursorLockMode.Locked;
    }

    //called once per frame
    void Update()
    {
        //built-in input collection for mouse axes multiplied by mouseSensitivity and
        //Time.deltaTime so that it's independant of framerate
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        //allows camera to tilt on x axis, using clamp so that it doesn't go beyond
        //"normal" head movement to look behind the player
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //applies the rotation using Euler angles so that it can be clampped
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        
        //allows camera to pan on x axis
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
