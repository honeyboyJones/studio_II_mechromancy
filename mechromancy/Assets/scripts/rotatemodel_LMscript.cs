using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatemodel_LMscript : MonoBehaviour
{
    public float xAngle;
    public float yAngle;
    public float zAngle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(xAngle, yAngle, zAngle, Space.Self);
    }
}
