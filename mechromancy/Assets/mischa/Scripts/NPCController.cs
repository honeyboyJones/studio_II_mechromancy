using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MathUtil; //direct access to public static content in util script without references

public class NPCController : MonoBehaviour
{
    GameObject player;

    [SerializeField]
    private float moveSpeed = 2.0f;

    Vector3 getInput;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Util.CanSeeObj(player, gameObject, 0.9f))
        {
            //Debug.Log("player in sight");
        }
        Util.ObjSide(player, gameObject);
    }

    private void FixedUpdate()
    {
        GetComponent<Rigidbody>().velocity = getInput * moveSpeed; //locate rb comp, set velocity

        Vector3 lookPos = new Vector3(
                transform.position.x + GetComponent<Rigidbody>().velocity.x,
                transform.position.y,
                transform.position.z + GetComponent<Rigidbody>().velocity.z
            );
        transform.LookAt(lookPos);
    }
}